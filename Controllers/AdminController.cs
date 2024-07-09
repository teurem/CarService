using digitization.Data;
using digitization.Models;
using digitization.Services;
using digitization.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace digitization.Controllers
{
    [Authorize(Roles = RoleService.AdminRole)]
    public class AdminController : Controller {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;
        private readonly RoleService roleService;


        public AdminController(UserManager<User> userManager, ApplicationDbContext context, RoleService roleService) {
            this.userManager = userManager;
            this.context = context;
            this.roleService = roleService;

        }

        public async Task<IActionResult> Index() {
            var currentUserId =  context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CurrentUserId = currentUserId.Id;
            IEnumerable<UserViewModel> users = context.Users.ToList().Select(u => new UserViewModel() {
                Role = roleService.GetRole(u.Id),
                Id = u.Id,
                Email = u.Email
            });

            return View(users);
        }

        [HttpGet]
        public IActionResult Create() {
            ViewData["Roles"] = new SelectList(context.Roles, "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel user) {
            if (ModelState.IsValid) {
                if (await userManager.FindByNameAsync(user.Email) == null) {
                    User identityUser = new User { Email = user.Email, UserName = user.Email, Surname = user.Surname, Name = user.Name, Patronymic = user.Patronymic };
                    IdentityResult result = await userManager.CreateAsync(identityUser, user.Password);

                    if (result.Succeeded) {
                        await roleService.AddRolesAsync(identityUser, user.Role);
                        return RedirectToAction(nameof(Index));
                    } else foreach (var error in result.Errors) 
                                ModelState.AddModelError(string.Empty, error.Description);

                } else ModelState.AddModelError(string.Empty, "Этот пользователь уже существует");

            } else ModelState.AddModelError(string.Empty, "Ошибка валидации страницы");
            ViewData["Roles"] = new SelectList(context.Roles, "Name");
            return View(user);
        }

        public async Task<IActionResult> Delete(string? id) {
            if (id == null)
                return NotFound();
            
            User user = await userManager.FindByIdAsync(id);

            if (user == null) 
                return NotFound();

            return View(new DeleteUserViewModel { Id = user.Id, Email = user.Email, Role = roleService.GetRole(user.Id) });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            User user = await userManager.FindByIdAsync(id);
            if (user != null) {
                try
                {
                    var userOrdersPointStatuses = context.OrdersPointStatuses.Where(a => a.ExecutorId == id && a.PointId != 103)
                        .ToList();

                    if(userOrdersPointStatuses.Count > 0)
                    {
                        ModelState.AddModelError("", "Вы не можете удалить этого пользователя, так как у этого пользователя есть не завершенные заказы !!!");
                        return View("Delete", new DeleteUserViewModel { Id = user.Id, Email = user.Email, Role = roleService.GetRole(user.Id) });
                    }
                    
                    IdentityResult result = await userManager.DeleteAsync(user);
                }
                catch 
                {
                }
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

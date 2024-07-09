using digitization.Data;
using digitization.Models;
using digitization.Services;
using digitization.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace digitization.Controllers {
    public class AccountController : Controller {

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, ApplicationDbContext context) {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null) {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                var result =
                    await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
                if (result.Succeeded) {
                    var user = userManager.FindByEmailAsync(model.Email).Result;
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl)) {
                        return Redirect(model.ReturnUrl);
                    } else {
                        return RedirectToAction("Index", "Orders");
                    }
                } else {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout() {
            var user = userManager.GetUserAsync(User).Result;
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Orders");
        }

        public IActionResult AccessDenied() {
            return View();
        }

        public async Task<IActionResult> ChangePassword() {
            var currentUserId = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (currentUserId == null)
                return NotFound();
            User user = await userManager.FindByIdAsync(currentUserId.Id);
            if (user == null) {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model) {
            if (ModelState.IsValid) {
                User user = await userManager.FindByIdAsync(model.Id);
                if (user != null) {
                    var _passwordValidator =
                    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;
                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(userManager, user, model.Password);
                    if (result.Succeeded) {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                        await userManager.UpdateAsync(user);
                        return RedirectToAction("Index", "Orders");
                    } else {
                        foreach (var error in result.Errors) {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                } else {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return RedirectToAction("Index", "Orders");
        }
    }
}

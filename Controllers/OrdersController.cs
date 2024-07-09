using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using digitization.Data;
using digitization.Models;
using digitization.ViewModels;
using digitization.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;
using static NuGet.Packaging.PackagingConstants;

namespace digitization.Controllers
{
    [Authorize(Roles = $"{RoleService.MechanicRole},{RoleService.AutoElectricianRole}," +
        $"{RoleService.WalkerRole},{RoleService.PainterRole},{RoleService.MotoristRole}")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleService _roleService;

        public OrdersController(ApplicationDbContext context, UserManager<User> userManager, RoleService roleService)
        {
            _context = context;
            _userManager = userManager;
            _roleService = roleService;
        }

        // GET: Orders
        public IActionResult Index(long? pointId = null)
        {
            Helper.SessionExtensions.Set(HttpContext.Session, "pointId", pointId);

            ViewBag.pointId = pointId;

            return View();
        }

        [HttpPost]
        public IActionResult LoadTable([FromBody] DtParameters dtParameters)
        {
            int dtdraw = dtParameters.draw;
            int startRec = dtParameters.start;
            int pageSize = dtParameters.length;

            var entities = _context.Orders.Select(a => a);

            var userId = _userManager.GetUserId(User);
            var userRole = _roleService.GetRole(userId);

            if(userRole != RoleService.AdminRole)
            {
                var ordersIds = _context.OrdersPointStatuses.Where(a => a.ExecutorId == userId).Select(a => a.OrdersId);
                entities = entities.Where(a => ordersIds.Contains(a.Id));
            }

            var totalResultsCount = entities.Count();

            var pointId = Helper.SessionExtensions.Get<long?>(HttpContext.Session, "pointId");

            if (pointId != null && userRole == RoleService.AdminRole)
            {
                entities = entities.Where(a => a.PointId == pointId);
            }
            else if(pointId != null)
            {
                var ordersIds = _context.OrdersPointStatuses.Where(a => a.ExecutorId == userId && a.PointId == pointId).Select(a => a.OrdersId);
                entities = entities.Where(a => ordersIds.Contains(a.Id));
            }

            var data = entities
                .OrderByDescending(a => a.CreatedAt);

            var filteredResultsCount = data.Count();
            var _data = data.Skip(startRec).Take(pageSize)
                .ToList()
                .Select(a => new OrdersViewModel
                {
                    Id = a.Id,
                    ClientFIO = a.ClientFIO,
                    ClientPhoneNumber = a.ClientPhoneNumber,
                    CarBrand = a.CarBrand,
                    CarModel = a.CarModel,
                    RepairInstructions = a.RepairInstructions,
                    Price = a.Price,
                    RoadMaps = (userRole == RoleService.AdminRole) ? GetRoadMapsForAdmin(a.PointId, a.Id) : GetRoadMaps(a.Id, userId)
                });

            return Json(new
            {
                draw = dtdraw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = _data
            });
        }

        [HttpGet("Orders/Movement")]
        public async Task<IActionResult> Movement(long id, long roadMapId)
        {
            var movement = new MovementViewModel();

            var roadMap = _context.RoadMaps.Find(roadMapId);

            if (roadMap == null)
            {
                return NotFound(roadMapId);
            }

            movement.EntityId = id;
            movement.RoadMapId = roadMapId;

            var user = await _userManager.GetUserAsync(User);
            var userRole = _roleService.GetRole(user.Id);

            if (userRole == RoleService.AdminRole)
            {
                movement.IsAdmin = true;

                var userIds = _context.OrdersPointStatuses.Where(a => a.OrdersId == id && a.PointId == roadMap.SourcePointId)
                    .Select(a => a.ExecutorId)
                    .ToList();

                var users = _userManager.Users.Where(a => userIds.Contains(a.Id)).ToList()
                    .Select(a => new { Id = a.Id, FullName = $"{a.Email} : {a.Surname} {a.Name} {a.Patronymic}", Role = _userManager.GetRolesAsync(a).Result.First() })
                    .ToList();

                ViewData["ExecutorsId"] = new SelectList(users, "Id", "FullName");
            }
            else
            {
                movement.UserId = user.Id;
                movement.User = $"{user.Email} : {user.Surname} {user.Name} {user.Patronymic}";
            }

            if (roadMap.ReasonId == 1002) //добавить запчасти
            {
                movement.IsAddSpareParts = true;
                movement.SpareParts = _context.Orders.Find(id).SpareParts;
            }

            return View(movement);
        }

        [HttpPost("Orders/Movement")]
        public async Task<IActionResult> Movement(MovementViewModel movement)
        {
            var roadMap = await _context.RoadMaps.FindAsync(movement.RoadMapId);

            var orders = await _context.Orders.FindAsync(movement.EntityId);
            
            var ordersPointStatus = await _context.OrdersPointStatuses.FindAsync(movement.EntityId, movement.UserId);

            ordersPointStatus.PointId = roadMap.TargetPointId;

            await _context.SaveChangesAsync();

            var ordersPoint = _context.OrdersPointStatuses
                .Where(a => a.OrdersId == movement.EntityId)
                .OrderByDescending(a => a.Order)
                .Select(a => a.PointId)
                .First();

            orders.PointId = ordersPoint;

            if (movement.IsAddSpareParts)
            {
                orders.SpareParts = movement.SpareParts;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(a => a.Mechanic)
                .Include(a => a.AutoElectrician)
                .Include(a => a.Walker)
                .Include(a => a.Painter)
                .Include(a => a.Motorist)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orders == null)
            {
                return NotFound();
            }

            var res = new OrdersDetailViewModel
            {
                ClientFIO = orders.ClientFIO,
                ClientPhoneNumber = orders.ClientPhoneNumber,
                CarBrand = orders.CarBrand,
                CarModel = orders.CarModel,
                RepairInstructions = orders.RepairInstructions,
                Price = orders.Price,
                Comment = orders.Comment,
                SpareParts = orders.SpareParts,
                CreatedAt = orders.CreatedAt,
                Mechanic = $"{orders.Mechanic?.Email} : {orders.Mechanic?.Surname} {orders.Mechanic?.Name} {orders.Mechanic?.Patronymic}",
                AutoElectrician = $"{orders.AutoElectrician?.Email} : {orders.AutoElectrician?.Surname} {orders.AutoElectrician?.Name} {orders.AutoElectrician?.Patronymic}",
                Walker = $"{orders.Walker?.Email} : {orders.Walker?.Surname} {orders.Walker?.Name} {orders.Walker?.Patronymic}",
                Painter = $"{orders.Painter?.Email} : {orders.Painter?.Surname} {orders.Painter?.Name} {orders.Painter?.Patronymic}",
                Motorist = $"{orders.Motorist?.Email} : {orders.Motorist?.Surname} {orders.Motorist?.Name} {orders.Motorist?.Patronymic}",
            };

            return View(res);
        }

        // GET: Orders/Create
        [Authorize(Roles = RoleService.AdminRole)]
        public IActionResult Create()
        {
            var users = _userManager.Users
                            .ToList()
                            .Where(a => !_userManager.GetRolesAsync(a).Result.Any(r => r.Equals(RoleService.AdminRole)))
                            .Select(a => new {Id = a.Id, FullName = $"{a.Email} : {a.Surname} {a.Name} {a.Patronymic}", Role = _userManager.GetRolesAsync(a).Result.First()});

            var mechanics = users.Where(a => a.Role == RoleService.MechanicRole).ToList();
            var autoElectricians = users.Where(a => a.Role == RoleService.AutoElectricianRole).ToList();
            var walkers = users.Where(a => a.Role == RoleService.WalkerRole).ToList();
            var painters = users.Where(a => a.Role == RoleService.PainterRole).ToList();
            var motorists = users.Where(a => a.Role == RoleService.MotoristRole).ToList();

            mechanics.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            autoElectricians.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            walkers.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            painters.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            motorists.Add(new { Id = "", FullName = "Выбрать", Role = "" });

            ViewData["MechanicId"] = new SelectList(mechanics.OrderBy(a => a.Id), "Id", "FullName");
            ViewData["AutoElectricianId"] = new SelectList(autoElectricians.OrderBy(a => a.Id), "Id", "FullName");
            ViewData["WalkerId"] = new SelectList(walkers.OrderBy(a => a.Id), "Id", "FullName");
            ViewData["PainterId"] = new SelectList(painters.OrderBy(a => a.Id), "Id", "FullName");
            ViewData["MotoristId"] = new SelectList(motorists.OrderBy(a => a.Id), "Id", "FullName");
            
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = RoleService.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdersModifyViewModel ordersViewModel)
        {
            if (ordersViewModel.MechanicId == null && ordersViewModel.AutoElectricianId == null && 
                ordersViewModel.WalkerId == null && ordersViewModel.PainterId == null && ordersViewModel.MotoristId == null)
            {
                ModelState.AddModelError("IsExecutorSelected", "Выберите хотя бы одного сотрудника");
            }
            if (ModelState.IsValid)
            {
                var orders = new Orders
                {
                    ClientFIO = ordersViewModel.ClientFIO,
                    ClientPhoneNumber = ordersViewModel.ClientPhoneNumber,
                    CarBrand = ordersViewModel.CarBrand,
                    CarModel = ordersViewModel.CarModel,
                    RepairInstructions = ordersViewModel.RepairInstructions,
                    Price = ordersViewModel.Price,
                    Comment = ordersViewModel.Comment,
                    MechanicId = ordersViewModel.MechanicId,
                    AutoElectricianId = ordersViewModel.AutoElectricianId,
                    WalkerId = ordersViewModel.WalkerId,
                    PainterId = ordersViewModel.PainterId,
                    MotoristId = ordersViewModel.MotoristId,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = _userManager.GetUserId(User)
                };

                _context.Add(orders);
                await _context.SaveChangesAsync();

                byte order = 1;
                if(ordersViewModel.MechanicId != null)
                {
                    var ordersPointStatus = new OrdersPointStatus 
                    {
                        OrdersId = orders.Id,
                        ExecutorId = ordersViewModel.MechanicId,
                        Order = order
                    };

                    _context.OrdersPointStatuses.Add(ordersPointStatus);
                    order++;
                }
                if(ordersViewModel.AutoElectricianId != null)
                {
                    var ordersPointStatus = new OrdersPointStatus 
                    {
                        OrdersId = orders.Id,
                        ExecutorId = ordersViewModel.AutoElectricianId,
                        Order = order
                    };

                    _context.OrdersPointStatuses.Add(ordersPointStatus);
                    order++;
                }
                if(ordersViewModel.WalkerId != null)
                {
                    var ordersPointStatus = new OrdersPointStatus 
                    {
                        OrdersId = orders.Id,
                        ExecutorId = ordersViewModel.WalkerId,
                        Order = order
                    };

                    _context.OrdersPointStatuses.Add(ordersPointStatus);
                    order++;
                }
                if(ordersViewModel.PainterId != null)
                {
                    var ordersPointStatus = new OrdersPointStatus 
                    {
                        OrdersId = orders.Id,
                        ExecutorId = ordersViewModel.PainterId,
                        Order = order
                    };

                    _context.OrdersPointStatuses.Add(ordersPointStatus);
                    order++;
                }
                if(ordersViewModel.MotoristId != null)
                {
                    var ordersPointStatus = new OrdersPointStatus 
                    {
                        OrdersId = orders.Id,
                        ExecutorId = ordersViewModel.MotoristId,
                        Order = order
                    };

                    _context.OrdersPointStatuses.Add(ordersPointStatus);
                    order++;
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            var users = _userManager.Users
                            .ToList()
                            .Where(a => !_userManager.GetRolesAsync(a).Result.Any(r => r.Equals(RoleService.AdminRole)))
                            .Select(a => new { Id = a.Id, FullName = $"{a.Email} : {a.Surname} {a.Name} {a.Patronymic}", Role = _userManager.GetRolesAsync(a).Result.First() });

            var mechanics = users.Where(a => a.Role == RoleService.MechanicRole).ToList();
            var autoElectricians = users.Where(a => a.Role == RoleService.AutoElectricianRole).ToList();
            var walkers = users.Where(a => a.Role == RoleService.WalkerRole).ToList();
            var painters = users.Where(a => a.Role == RoleService.PainterRole).ToList();
            var motorists = users.Where(a => a.Role == RoleService.MotoristRole).ToList();

            mechanics.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            autoElectricians.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            walkers.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            painters.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            motorists.Add(new { Id = "", FullName = "Выбрать", Role = "" });

            ViewData["MechanicId"] = new SelectList(mechanics.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.MechanicId);
            ViewData["AutoElectricianId"] = new SelectList(autoElectricians.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.AutoElectricianId);
            ViewData["WalkerId"] = new SelectList(walkers.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.WalkerId);
            ViewData["PainterId"] = new SelectList(painters.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.PainterId);
            ViewData["MotoristId"] = new SelectList(motorists.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.MotoristId);

            return View(ordersViewModel);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = RoleService.AdminRole)]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FirstOrDefaultAsync(a => a.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            var res = new OrdersModifyViewModel
            {
                ClientFIO = orders.ClientFIO,
                ClientPhoneNumber = orders.ClientPhoneNumber,
                CarBrand = orders.CarBrand,
                CarModel = orders.CarModel,
                RepairInstructions = orders.RepairInstructions,
                Price = orders.Price,
                Comment = orders.Comment,
                MechanicId = orders.MechanicId,
                AutoElectricianId = orders.AutoElectricianId,
                WalkerId = orders.WalkerId,
                PainterId = orders.PainterId,
                MotoristId = orders.MotoristId,
            };

            var users = _userManager.Users
                            .ToList()
                            .Where(a => !_userManager.GetRolesAsync(a).Result.Any(r => r.Equals(RoleService.AdminRole)))
                            .Select(a => new { Id = a.Id, FullName = $"{a.Email} : {a.Surname} {a.Name} {a.Patronymic}", Role = _userManager.GetRolesAsync(a).Result.First() });

            var mechanics = users.Where(a => a.Role == RoleService.MechanicRole).ToList();
            var autoElectricians = users.Where(a => a.Role == RoleService.AutoElectricianRole).ToList();
            var walkers = users.Where(a => a.Role == RoleService.WalkerRole).ToList();
            var painters = users.Where(a => a.Role == RoleService.PainterRole).ToList();
            var motorists = users.Where(a => a.Role == RoleService.MotoristRole).ToList();

            mechanics.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            autoElectricians.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            walkers.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            painters.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            motorists.Add(new { Id = "", FullName = "Выбрать", Role = "" });

            ViewData["MechanicId"] = new SelectList(mechanics.OrderBy(a => a.Id), "Id", "FullName", orders.MechanicId);
            ViewData["AutoElectricianId"] = new SelectList(autoElectricians.OrderBy(a => a.Id), "Id", "FullName", orders.AutoElectricianId);
            ViewData["WalkerId"] = new SelectList(walkers.OrderBy(a => a.Id), "Id", "FullName", orders.WalkerId);
            ViewData["PainterId"] = new SelectList(painters.OrderBy(a => a.Id), "Id", "FullName", orders.PainterId);
            ViewData["MotoristId"] = new SelectList(motorists.OrderBy(a => a.Id), "Id", "FullName", orders.MotoristId);
            ViewBag.Id = orders.Id;

            return View(res);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = RoleService.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, OrdersModifyViewModel ordersViewModel)
        {
            if (id != ordersViewModel.Id)
            {
                return NotFound();
            }

            if (ordersViewModel.MechanicId == null && ordersViewModel.AutoElectricianId == null &&
                ordersViewModel.WalkerId == null && ordersViewModel.PainterId == null && ordersViewModel.MotoristId == null)
            {
                ModelState.AddModelError("IsExecutorSelected", "Выберите хотя бы одного сотрудника");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var orders = await _context.Orders.FirstAsync(a => a.Id == id);

                    orders.ClientFIO = ordersViewModel.ClientFIO;
                    orders.ClientPhoneNumber = ordersViewModel.ClientPhoneNumber;
                    orders.CarBrand = ordersViewModel.CarBrand; 
                    orders.CarModel = ordersViewModel.CarModel;
                    orders.RepairInstructions = ordersViewModel.RepairInstructions;
                    orders.Price = ordersViewModel.Price;
                    orders.Comment = ordersViewModel.Comment;
                    orders.MechanicId = ordersViewModel.MechanicId;
                    orders.AutoElectricianId = ordersViewModel.AutoElectricianId;
                    orders.WalkerId = ordersViewModel.WalkerId;
                    orders.PainterId = ordersViewModel.PainterId;
                    orders.MotoristId = ordersViewModel.MotoristId;

                    _context.Orders.Update(orders);

                    var ordersPointStatuses = _context.OrdersPointStatuses.Where(a => a.OrdersId == id);
                    _context.OrdersPointStatuses.RemoveRange(ordersPointStatuses);

                    byte order = 1;
                    if (ordersViewModel.MechanicId != null)
                    {
                        var ordersPointStatus = new OrdersPointStatus
                        {
                            OrdersId = orders.Id,
                            ExecutorId = ordersViewModel.MechanicId,
                            Order = order
                        };

                        _context.OrdersPointStatuses.Add(ordersPointStatus);
                        order++;
                    }
                    if (ordersViewModel.AutoElectricianId != null)
                    {
                        var ordersPointStatus = new OrdersPointStatus
                        {
                            OrdersId = orders.Id,
                            ExecutorId = ordersViewModel.AutoElectricianId,
                            Order = order
                        };

                        _context.OrdersPointStatuses.Add(ordersPointStatus);
                        order++;
                    }
                    if (ordersViewModel.WalkerId != null)
                    {
                        var ordersPointStatus = new OrdersPointStatus
                        {
                            OrdersId = orders.Id,
                            ExecutorId = ordersViewModel.WalkerId,
                            Order = order
                        };

                        _context.OrdersPointStatuses.Add(ordersPointStatus);
                        order++;
                    }
                    if (ordersViewModel.PainterId != null)
                    {
                        var ordersPointStatus = new OrdersPointStatus
                        {
                            OrdersId = orders.Id,
                            ExecutorId = ordersViewModel.PainterId,
                            Order = order
                        };

                        _context.OrdersPointStatuses.Add(ordersPointStatus);
                        order++;
                    }
                    if (ordersViewModel.MotoristId != null)
                    {
                        var ordersPointStatus = new OrdersPointStatus
                        {
                            OrdersId = orders.Id,
                            ExecutorId = ordersViewModel.MotoristId,
                            Order = order
                        };

                        _context.OrdersPointStatuses.Add(ordersPointStatus);
                        order++;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(ordersViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            var users = _userManager.Users
                            .ToList()
                            .Where(a => !_userManager.GetRolesAsync(a).Result.Any(r => r.Equals(RoleService.AdminRole)))
                            .Select(a => new { Id = a.Id, FullName = $"{a.Email} : {a.Surname} {a.Name} {a.Patronymic}", Role = _userManager.GetRolesAsync(a).Result.First() });
            
            var mechanics = users.Where(a => a.Role == RoleService.MechanicRole).ToList();
            var autoElectricians = users.Where(a => a.Role == RoleService.AutoElectricianRole).ToList();
            var walkers = users.Where(a => a.Role == RoleService.WalkerRole).ToList();
            var painters = users.Where(a => a.Role == RoleService.PainterRole).ToList();
            var motorists = users.Where(a => a.Role == RoleService.MotoristRole).ToList();

            mechanics.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            autoElectricians.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            walkers.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            painters.Add(new { Id = "", FullName = "Выбрать", Role = "" });
            motorists.Add(new { Id = "", FullName = "Выбрать", Role = "" });

            ViewData["MechanicId"] = new SelectList(mechanics.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.MechanicId);
            ViewData["AutoElectricianId"] = new SelectList(autoElectricians.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.AutoElectricianId);
            ViewData["WalkerId"] = new SelectList(walkers.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.WalkerId);
            ViewData["PainterId"] = new SelectList(painters.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.PainterId);
            ViewData["MotoristId"] = new SelectList(motorists.OrderBy(a => a.Id), "Id", "FullName", ordersViewModel.MotoristId);
            ViewBag.Id = id;

            return View(ordersViewModel);
        }

        // Delete: Orders/Delete?Id=5
        [Authorize(Roles = RoleService.AdminRole)]
        [HttpDelete]
        public async Task Delete(long id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                _context.Orders.Remove(order);

                var ordersPointStatuses = _context.OrdersPointStatuses.Where(a => a.OrdersId == id);
                _context.OrdersPointStatuses.RemoveRange(ordersPointStatuses);

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        private bool OrdersExists(long id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private List<RoadMapViewModel> GetRoadMaps(long entityId, string userId)
        {
            var res = new List<RoadMapViewModel>();

            var ordersPointStatus = _context.OrdersPointStatuses.Find(entityId, userId);
                
            if (ordersPointStatus.Order != 1)
            {
                var previusOrdersPointStatus = _context.OrdersPointStatuses.First(a => a.OrdersId == entityId && a.Order == (ordersPointStatus.Order - 1));
                if(previusOrdersPointStatus.PointId == 103)
                {
                    res = _context.RoadMaps.Where(a => a.SourcePointId == ordersPointStatus.PointId)
                    .Include(a => a.Reason)
                    .Select(a => new RoadMapViewModel
                    {
                        Id = a.Id,
                        EntityId = entityId,
                        Reason = a.Reason
                    })
                    .ToList();
                }
            }
            else
            {
                res = _context.RoadMaps.Where(a => a.SourcePointId == ordersPointStatus.PointId)
                    .Include(a => a.Reason)
                    .Select(a => new RoadMapViewModel
                    {
                        Id = a.Id,
                        EntityId = entityId,
                        Reason = a.Reason
                    })
                    .ToList();
            }

            return res;
        }
        private List<RoadMapViewModel> GetRoadMapsForAdmin(long? pointId, long entityId)
        {
            var res = new List<RoadMapViewModel>();

            if (pointId.HasValue)
            {
                var ordersPointStatus = from ops in _context.OrdersPointStatuses
                                        where ops.OrdersId == entityId
                                        group ops by ops.PointId into g
                                        select g.Key;
                
                res = _context.RoadMaps.Where(a => ordersPointStatus.Contains(a.SourcePointId))
                    .Include(a => a.Reason)
                    .Select(a => new RoadMapViewModel
                    {
                        Id = a.Id,
                        EntityId = entityId,
                        Reason = a.Reason
                    })
                    .ToList();
            }

            return res;
        }
    }
}

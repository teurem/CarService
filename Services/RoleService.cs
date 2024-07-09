using digitization.Data;
using digitization.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace digitization.Services {
    public class RoleService {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        public const string AdminRole  = "Администратор";
        public const string MechanicRole = "Механик";
        public const string AutoElectricianRole  = "Автоэлектрик";
        public const string WalkerRole = "Ходовщик";
        public const string PainterRole = "Маляр";
        public const string MotoristRole = "Моторист";
        private string adminRoleId;
        private string mechanicRoleId;
        private string autoElectricianRoleId;
        private string walkerRoleId;
        private string painterRoleId;
        private string motoristRoleId;
        public RoleService(ApplicationDbContext context, UserManager<User> userManager) {
            this.context = context;
            this.userManager = userManager;
            adminRoleId = context.Roles.Where(r => r.Name == AdminRole).Select(s => s.Id).FirstOrDefault() ?? string.Empty;
            mechanicRoleId = context.Roles.Where(r => r.Name == MechanicRole).Select(s => s.Id).FirstOrDefault() ?? string.Empty;
            autoElectricianRoleId = context.Roles.Where(r => r.Name == AutoElectricianRole).Select(s => s.Id).FirstOrDefault() ?? string.Empty;
            walkerRoleId = context.Roles.Where(r => r.Name == WalkerRole).Select(s => s.Id).FirstOrDefault() ?? string.Empty;
            painterRoleId = context.Roles.Where(r => r.Name == PainterRole).Select(s => s.Id).FirstOrDefault() ?? string.Empty;
            motoristRoleId = context.Roles.Where(r => r.Name == MotoristRole).Select(s => s.Id).FirstOrDefault() ?? string.Empty;
        }

        public string GetRole(string id) {
            return context.UserRoles.Any(s => s.UserId == id && s.RoleId == adminRoleId) ? AdminRole :
                context.UserRoles.Any(s => s.UserId == id && s.RoleId == mechanicRoleId) ? MechanicRole :
                context.UserRoles.Any(s => s.UserId == id && s.RoleId == autoElectricianRoleId) ? AutoElectricianRole :
                context.UserRoles.Any(s => s.UserId == id && s.RoleId == walkerRoleId) ? WalkerRole :
                context.UserRoles.Any(s => s.UserId == id && s.RoleId == painterRoleId) ? PainterRole :
                context.UserRoles.Any(s => s.UserId == id && s.RoleId == motoristRoleId) ? MotoristRole : "none role";
        }

        public async Task AddRolesAsync(User identityUser, string role) {
            switch (role) {
                case MechanicRole:
                    await userManager.AddToRoleAsync(identityUser, MechanicRole);
                    return;
                case AutoElectricianRole:
                    await userManager.AddToRoleAsync(identityUser, AutoElectricianRole);
                    return;
                case WalkerRole:
                    await userManager.AddToRoleAsync(identityUser, WalkerRole);
                    return;
                case PainterRole:
                    await userManager.AddToRoleAsync(identityUser, PainterRole);
                    return;
                case MotoristRole:
                    await userManager.AddToRoleAsync(identityUser, MotoristRole);
                    return;
                case AdminRole:
                    await userManager.AddToRoleAsync(identityUser, AdminRole);
                    await userManager.AddToRoleAsync(identityUser, MechanicRole);
                    await userManager.AddToRoleAsync(identityUser, AutoElectricianRole);
                    await userManager.AddToRoleAsync(identityUser, WalkerRole);
                    await userManager.AddToRoleAsync(identityUser, PainterRole);
                    await userManager.AddToRoleAsync(identityUser, MotoristRole);
                    return;
            }
        }
    }
}

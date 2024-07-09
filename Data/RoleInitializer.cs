using digitization.Models;
using Microsoft.AspNetCore.Identity;

namespace digitization.Data {
    public class RoleInitializer {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) {
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("Администратор") == null) {
                await roleManager.CreateAsync(new IdentityRole("Администратор"));
            }
            if (await roleManager.FindByNameAsync("Механик") == null) {
                await roleManager.CreateAsync(new IdentityRole("Механик"));
            }
            if (await roleManager.FindByNameAsync("Автоэлектрик") == null) {
                await roleManager.CreateAsync(new IdentityRole("Автоэлектрик"));
            }
            if (await roleManager.FindByNameAsync("Ходовщик") == null) {
                await roleManager.CreateAsync(new IdentityRole("Ходовщик"));
            }
            if (await roleManager.FindByNameAsync("Маляр") == null) {
                await roleManager.CreateAsync(new IdentityRole("Маляр"));
            }
            if (await roleManager.FindByNameAsync("Моторист") == null) {
                await roleManager.CreateAsync(new IdentityRole("Моторист"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null) {
                User admin = new User { Email = adminEmail, UserName = adminEmail, Surname = "Admin", Name = "Admin"};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(admin, "Администратор");
                    await userManager.AddToRoleAsync(admin, "Механик");
                    await userManager.AddToRoleAsync(admin, "Автоэлектрик");
                    await userManager.AddToRoleAsync(admin, "Ходовщик");
                    await userManager.AddToRoleAsync(admin, "Маляр");
                    await userManager.AddToRoleAsync(admin, "Моторист");
                }
            }
        }
    }
}

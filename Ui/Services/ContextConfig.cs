using DAL;
using DAL.Data;
using DAL.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ui.Services
{
    public class ContextConfig
    {
        private static readonly string seedAdminEmail = "admin@gmail.com";
        public static async Task SeedDataAsync(ShippingContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await SeedUserAsync(userManager, roleManager);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Ensure roles exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!await roleManager.RoleExistsAsync("Reviewer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Reviewer"));
            }

            if (!await roleManager.RoleExistsAsync("Operation"))
            {
                await roleManager.CreateAsync(new IdentityRole("Operation"));
            }

            if (!await roleManager.RoleExistsAsync("Operation Manager"))
            {
                await roleManager.CreateAsync(new IdentityRole("Operation Manager"));
            }

            // Ensure admin user exists
            var adminEmail = seedAdminEmail;
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var id = Guid.NewGuid().ToString();
                adminUser = new ApplicationUser
                {
                    Id = id,
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "admin",
                    LastName = "admin",
                    Phone = "65656566"
                };
                var result = await userManager.CreateAsync(adminUser, "admin123456");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var reviewerUser = await userManager.FindByEmailAsync("reviewer@gmail.com");
            if (reviewerUser == null)
            {
                var id = Guid.NewGuid().ToString();
                reviewerUser = new ApplicationUser
                {
                    Id = id,
                    UserName = "reviewer@gmail.com",
                    Email = "reviewer@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "reviewer",
                    LastName = "reviewer",
                    Phone = "123456"
                };
                var result = await userManager.CreateAsync(reviewerUser, "admin123456");
                await userManager.AddToRoleAsync(reviewerUser, "Reviewer");
            }

            var operationUser = await userManager.FindByEmailAsync("operation@gmail.com");
            if (operationUser == null)
            {
                var id = Guid.NewGuid().ToString();
                operationUser = new ApplicationUser
                {
                    Id = id,
                    UserName = "operation@gmail.com",
                    Email = "operation@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "operation",
                    LastName = "operation",
                    Phone = "123456"
                };
                var result = await userManager.CreateAsync(operationUser, "admin123456");
                await userManager.AddToRoleAsync(operationUser, "Operation");
            }

            var operationManagerUser = await userManager.FindByEmailAsync("operationman@gmail.com");
            if (operationManagerUser == null)
            {
                var id = Guid.NewGuid().ToString();
                operationManagerUser = new ApplicationUser
                {
                    Id = id,
                    UserName = "operationman@gmail.com",
                    Email = "operationman@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "operation manager",
                    LastName = "operation manager",
                    Phone = "123456"
                };
                var result = await userManager.CreateAsync(operationManagerUser, "admin123456");
                await userManager.AddToRoleAsync(operationManagerUser, "Operation Manager");
            }
        }
    }
}

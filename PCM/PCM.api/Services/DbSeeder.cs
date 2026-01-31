using Microsoft.AspNetCore.Identity;
using PCM.api.Data;
using PCM.api.Models;

namespace PCM.api.Services
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            //1. Seed Roles
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Treasurer", "Referee", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //2. Seed Admin User
            var powerUser = new IdentityUser
            {
                UserName = "admin@pcm.com",
                Email = "admin@pcm.com",
            };
            var adminCheck = await userManager.FindByEmailAsync(powerUser.Email);
            if (adminCheck != null)
            {
                // Delete old admin user if exists
                await userManager.DeleteAsync(adminCheck);
            }

            var createPowerUser = await userManager.CreateAsync(powerUser, "Admin@123");
            if (createPowerUser.Succeeded)
            {
                await userManager.AddToRoleAsync(powerUser, "Admin");
            }

            //2b. Seed Regular User
            var regularUser = new IdentityUser
            {
                UserName = "user@pcm.com",
                Email = "user@pcm.com",
            };
            var regularUserCheck = await userManager.FindByEmailAsync(regularUser.Email);
            if (regularUserCheck != null)
            {
                // Delete old regular user if exists
                await userManager.DeleteAsync(regularUserCheck);
            }

            var createRegularUser = await userManager.CreateAsync(regularUser, "User@123");
            if (createRegularUser.Succeeded)
            {
                await userManager.AddToRoleAsync(regularUser, "Member");
            }

            //3. Seed App Data
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            // Seed Courts
            if (!context.Courts.Any())
            {
                context.Courts.AddRange(
                    new _999_Court { CourtName = "Sân 1", Number = 1, IsActive = true },
                    new _999_Court { CourtName = "Sân 2", Number = 2, IsActive = true },
                    new _999_Court { CourtName = "Sân 3", Number = 3, IsActive = true }
                );
                context.SaveChanges();
            }

        }
    }
}

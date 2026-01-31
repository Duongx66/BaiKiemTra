using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PCM.api.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var sp = scope.ServiceProvider;
        var roleManager = sp.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = sp.GetRequiredService<UserManager<IdentityUser>>();
        var db = sp.GetRequiredService<ApplicationDbContext>();

        // apply migrations
        await db.Database.MigrateAsync();

        // ensure roles
        var roles = new[] { "Admin", "User" };
        foreach (var r in roles)
        {
            if (!await roleManager.RoleExistsAsync(r))
                await roleManager.CreateAsync(new IdentityRole(r));
        }

        // create admin
        var config = sp.GetRequiredService<IConfiguration>();
        var adminEmail = config["AdminUser:Email"] ?? "admin@pcm.local";
        var adminPassword = config["AdminUser:Password"] ?? "Admin@12345!";

        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin == null)
        {
            admin = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
            var res = await userManager.CreateAsync(admin, adminPassword);
            if (res.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
        else
        {
            if (!await userManager.IsInRoleAsync(admin, "Admin"))
                await userManager.AddToRoleAsync(admin, "Admin");
        }

        // optionally seed minimal data if needed (skip heavy sample data)
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PCM.api.Data;
using PCM.api.Services;

var builder = WebApplication.CreateBuilder(args);

// =======================
// DATABASE (SQL SERVER)
// =======================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =======================
// IDENTITY
// =======================
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// =======================
// AUTHENTICATION CONFIGURATION
// =======================
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// =======================
// MVC + RAZOR
// =======================
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// =======================
// SWAGGER
// =======================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =======================
// CORS
// =======================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
    );
});

var app = builder.Build();

// =======================
// SEED DATA
// =======================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Could not migrate the database.");
    }

    await DbSeeder.SeedRolesAndAdminAsync(services);
}

// =======================
// MIDDLEWARE
// =======================
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

// =======================
// ROUTING
// =======================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();
app.MapControllers();

app.Run();
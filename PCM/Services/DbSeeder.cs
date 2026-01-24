using PCM.Data;
using PCM.Models;

namespace PCM.Services
{
    public static class DbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
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

            // Seed Members
            if (!context.Members.Any())
            {
                context.Members.AddRange(
                    new _999_Member { FullName = "Nguyễn Văn A" },
                    new _999_Member { FullName = "Trần Văn B" }
                );
                context.SaveChanges();
            }
        }
    }
}

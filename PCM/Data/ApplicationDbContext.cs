using Microsoft.EntityFrameworkCore;
using PCM.Models;

namespace PCM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<_999_Court> Courts { get; set; }
        public DbSet<_999_Member> Members { get; set; }
        public DbSet<_999_Booking> Bookings { get; set; }
    }
}

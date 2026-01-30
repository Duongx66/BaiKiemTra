using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCM.Models;

namespace PCM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<_999_Court> Courts { get; set; }
        public DbSet<_999_Member> Members { get; set; }
        public DbSet<_999_Booking> Bookings { get; set; }
        public DbSet<_999_Match> Matches { get; set; }
        public DbSet<_999_Challenge> Challenges { get; set; }
        public DbSet<_999_Participant> Participants { get; set; }
        public DbSet<_999_Transaction> Transactions { get; set; }
        public DbSet<_999_News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Matches foreign keys to use NO ACTION to avoid multiple cascade paths
            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player1)
                .WithMany()
                .HasForeignKey(m => m.Player1Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player2)
                .WithMany()
                .HasForeignKey(m => m.Player2Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player3)
                .WithMany()
                .HasForeignKey(m => m.Player3Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player4)
                .WithMany()
                .HasForeignKey(m => m.Player4Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure Participants
            modelBuilder.Entity<_999_Participant>()
                .HasOne(p => p.Challenge)
                .WithMany(c => c.Participants)
                .HasForeignKey(p => p.ChallengeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<_999_Participant>()
                .HasOne(p => p.Member)
                .WithMany()
                .HasForeignKey(p => p.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Transactions
            modelBuilder.Entity<_999_Transaction>()
                .HasOne(t => t.Member)
                .WithMany()
                .HasForeignKey(t => t.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

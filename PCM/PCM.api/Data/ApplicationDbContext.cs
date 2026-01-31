using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCM.Models;

namespace PCM.Data
{
    // ⚠️ QUAN TRỌNG:
    // Phải chỉ rõ IdentityUser để tránh lỗi khi deploy
    public class ApplicationDbContext 
        : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        {
        }

        // =========================
        // DB SETS
        // =========================
        public DbSet<_999_Court> Courts { get; set; }
        public DbSet<_999_Member> Members { get; set; }
        public DbSet<_999_Booking> Bookings { get; set; }
        public DbSet<_999_Match> Matches { get; set; }
        public DbSet<_999_Challenge> Challenges { get; set; }
        public DbSet<_999_Participant> Participants { get; set; }
        public DbSet<_999_Transaction> Transactions { get; set; }
        public DbSet<_999_News> News { get; set; }

        // =========================
        // MODEL CONFIG
        // =========================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // MATCHES – tránh multiple cascade paths
            // (bắt buộc khi dùng SQL Server / Postgres)
            // =========================
            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player1)
                .WithMany()
                .HasForeignKey(m => m.Player1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player2)
                .WithMany()
                .HasForeignKey(m => m.Player2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player3)
                .WithMany()
                .HasForeignKey(m => m.Player3Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<_999_Match>()
                .HasOne(m => m.Player4)
                .WithMany()
                .HasForeignKey(m => m.Player4Id)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // PARTICIPANTS
            // =========================
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

            // =========================
            // TRANSACTIONS
            // =========================
            modelBuilder.Entity<_999_Transaction>()
                .HasOne(t => t.Member)
                .WithMany()
                .HasForeignKey(t => t.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // OPTIONAL: đặt tên bảng Identity gọn hơn (khuyên dùng)
            // =========================
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
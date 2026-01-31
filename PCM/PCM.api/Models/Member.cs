using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCM.api.Models
{
    public class _999_Member
    {
        [Key]
        public int Id { get; set; }

        // Link to the Identity User
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public virtual IdentityUser? IdentityUser { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = "";

        public DateTime JoinDate { get; set; }

        public double DuprRating { get; set; }

        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }

        [NotMapped]
        public double WinRate
        {
            get
            {
                return MatchesPlayed > 0 ? (double)MatchesWon / MatchesPlayed * 100 : 0;
            }
        }

        public _999_Member()
        {
            JoinDate = DateTime.UtcNow;
            DuprRating = 0.0;
        }
    }
}
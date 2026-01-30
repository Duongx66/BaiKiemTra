using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCM.Models
{
    public class _999_Match
    {
        [Key]
        public int Id { get; set; }

        // Thông tin cơ bản
        [Required(ErrorMessage = "Vui lòng chọn ngày giờ trận đấu")]
        public DateTime MatchDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn sân")]
        public int CourtId { get; set; }
        [ForeignKey("CourtId")]
        public virtual _999_Court? Court { get; set; }

        // Loại trận: Single (1vs1) hoặc Doubles (2vs2)
        [Required(ErrorMessage = "Vui lòng chọn loại trận")]
        public string MatchType { get; set; } = "Single"; // Single, Doubles

        // Đơn: 2 người
        [Required(ErrorMessage = "Vui lòng chọn Người chơi 1")]
        public int Player1Id { get; set; }
        [ForeignKey("Player1Id")]
        public virtual _999_Member? Player1 { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Người chơi 2")]
        public int Player2Id { get; set; }
        [ForeignKey("Player2Id")]
        public virtual _999_Member? Player2 { get; set; }

        // Doubles: 4 người (Team A: Player1 + Player2, Team B: Player3 + Player4)
        public int? Player3Id { get; set; }
        [ForeignKey("Player3Id")]
        public virtual _999_Member? Player3 { get; set; }

        public int? Player4Id { get; set; }
        [ForeignKey("Player4Id")]
        public virtual _999_Member? Player4 { get; set; }

        // Kết quả
        public int? WinnerId { get; set; } // Cho Single, hoặc Player ID đại diện team thắng
        public string? WinnerTeam { get; set; } // "Team A" hoặc "Team B" cho Doubles

        // Điểm (nếu có)
        public int? Player1Score { get; set; }
        public int? Player2Score { get; set; }

        // Trạng thái: Pending, Completed, Cancelled
        [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
        public string Status { get; set; } = "Pending";

        // Có tính Rank DUPR hay không
        public bool IsRanked { get; set; } = true;

        // Ghi chú
        public string? Notes { get; set; }

        // Metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}

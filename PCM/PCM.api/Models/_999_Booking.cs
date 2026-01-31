namespace PCM.api.Models
{
    public class _999_Booking
    {
        public int Id { get; set; }

        public int CourtId { get; set; }
        public int MemberId { get; set; }

        public DateTime BookingDate { get; set; }

        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public string Status { get; set; } = "Booked";

        // Navigation properties
        public virtual _999_Court? Court { get; set; }
        public virtual _999_Member? Member { get; set; }
    }
}

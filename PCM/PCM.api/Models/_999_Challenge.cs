namespace PCM.api.Models
{
    public class _999_Challenge
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        // Type: Tournament, FriendlyMatch, RankedMatch
        public string ChallengeType { get; set; } = "Tournament";
        
        // Format: Singles, Doubles
        public string Format { get; set; } = "Singles";
        
        // Status: Open, Ongoing, Completed, Cancelled
        public string Status { get; set; } = "Open";
        
        public decimal EntryFee { get; set; } = 0;
        
        public decimal Prize { get; set; } = 0;
        
        public int MaxParticipants { get; set; } = 100;
        
        public int CurrentParticipants { get; set; } = 0;
        
        // Navigation
        public virtual ICollection<_999_Participant> Participants { get; set; } = new List<_999_Participant>();
    }
}

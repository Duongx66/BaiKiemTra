namespace PCM.api.Models
{
    public class _999_Participant
    {
        public int Id { get; set; }
        
        public int ChallengeId { get; set; }
        
        public int MemberId { get; set; }
        
        public DateTime JoinedDate { get; set; } = DateTime.Now;
        
        // Status: Registered, Confirmed, Completed, Withdrawn
        public string Status { get; set; } = "Registered";
        
        public int? PartnerMemberId { get; set; } = null; // For Doubles
        
        // Navigation
        public virtual _999_Challenge? Challenge { get; set; }
        public virtual _999_Member? Member { get; set; }
        public virtual _999_Member? PartnerMember { get; set; }
    }
}

namespace PCM.api.Models
{
    public class _999_Transaction
    {
        public int Id { get; set; }
        
        public int MemberId { get; set; }
        
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        
        // Type: Income, Expense
        public string Type { get; set; } = "Income";
        
        // Category examples: MembershipFee, CourtFee, Equipment, Prize, etc.
        public string Category { get; set; } = string.Empty;
        
        public decimal Amount { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public string Notes { get; set; } = string.Empty;
        
        // Navigation
        public virtual _999_Member? Member { get; set; }
    }
}

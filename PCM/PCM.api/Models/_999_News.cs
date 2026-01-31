namespace PCM.api.Models
{
    public class _999_News
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        
        public string? ImageUrl { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        public string CreatedBy { get; set; } = string.Empty; // User ID
        
        public bool IsPinned { get; set; } = false;
        
        // Status: Published, Draft
        public string Status { get; set; } = "Published";
    }
}

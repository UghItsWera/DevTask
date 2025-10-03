namespace VertoDevTest.Models
{
    public class ContentPanel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public string? IconClass { get; set; } // For Font Awesome icons
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
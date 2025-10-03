using System.ComponentModel.DataAnnotations;

namespace VertoDevTest.Models
{
    public class MediaItem
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string ContentType { get; set; } = string.Empty;

        // stored relative path like "uploads/imagename.jpg"
        [Required, StringLength(500)]
        public string Url { get; set; } = string.Empty;

        [StringLength(250)]
        public string AltText { get; set; } = string.Empty;
    }
}
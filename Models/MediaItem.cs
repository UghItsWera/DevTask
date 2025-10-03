using System.ComponentModel.DataAnnotations;

namespace VertoDevTest.Models
{
    public class MediaItem
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string FileName { get; set; }

        [Required, StringLength(255)]
        public string ContentType { get; set; }

        // stored relative path like "uploads/imagename.jpg"
        [Required, StringLength(500)]
        public string Url { get; set; }

        [StringLength(250)]
        public string AltText { get; set; }
    }
}
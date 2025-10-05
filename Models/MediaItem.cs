using System.ComponentModel.DataAnnotations;

namespace VertoDevTest.Models
{
    public class MediaItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; }

        [MaxLength(50)]
        public string? FileType { get; set; }

        public long FileSize { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
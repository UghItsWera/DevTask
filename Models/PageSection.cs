using System.ComponentModel.DataAnnotations;

namespace VertoDevTest.Models
{
    public class PageSection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string SectionType { get; set; } // Hero, Services, Portfolio, About

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string? Content { get; set; }

        [MaxLength(500)]
        public string? ImagePath { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }
    }
}
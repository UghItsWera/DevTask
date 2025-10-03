using System.ComponentModel.DataAnnotations;

namespace VertoDevTest.Models
{
    public class PageSection
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        [DataType(DataType.Html)]
        public string Body { get; set; } // stored as HTML/plain text

        // optional heading level metadata; helps SEO/editor control
        public string HtmlTag { get; set; } = "h2";

        // Link any image to this section:
        public int? MediaItemId { get; set; }
        public MediaItem MediaItem { get; set; }

        // ordering for homepage sections
        public int SortOrder { get; set; } = 0;
    }
}
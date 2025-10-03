namespace VertoDevTest.Models
{
    public class CompanyLogo
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string LogoPath { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
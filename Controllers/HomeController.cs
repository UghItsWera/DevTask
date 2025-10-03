using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VertoDevTest.Data;
using VertoDevTest.Models;
using System.Diagnostics;

namespace VertoDevTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var pageSections = await _context.PageSections
                    .Where(ps => ps.IsActive)
                    .OrderBy(ps => ps.DisplayOrder)
                    .ToListAsync();

                // If no sections exist, create default ones
                if (!pageSections.Any())
                {
                    await SeedDefaultContent();
                    pageSections = await _context.PageSections
                        .Where(ps => ps.IsActive)
                        .OrderBy(ps => ps.DisplayOrder)
                        .ToListAsync();
                }

                return View(pageSections);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading home page");
                return View(new List<PageSection>());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task SeedDefaultContent()
        {
            var defaultSections = new List<PageSection>
            {
                new PageSection
                {
                    SectionType = "Hero",
                    Title = "Creating Exceptional Workspaces",
                    Content = "Transform your commercial space into an agile, functional environment",
                    ImagePath = "/images/hero1.jpg",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new PageSection
                {
                    SectionType = "Hero",
                    Title = "Innovative Office Design",
                    Content = "Bespoke furniture and interior solutions",
                    ImagePath = "/images/hero2.jpg",
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new PageSection
                {
                    SectionType = "Services",
                    Title = "Custom built design & furniture solutions",
                    Content = "Specialists in transforming commercial spaces into agile, functional and empowering environments.",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new PageSection
                {
                    SectionType = "Portfolio",
                    Title = "Case Study Name Here",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam justo duo dolores.",
                    ImagePath = "/images/portfolio1.jpg",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new PageSection
                {
                    SectionType = "Portfolio",
                    Title = "Modern Office Space",
                    Content = "A contemporary workspace designed for collaboration and productivity. Features include flexible workstations and natural lighting.",
                    ImagePath = "/images/portfolio2.jpg",
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new PageSection
                {
                    SectionType = "Portfolio",
                    Title = "Executive Meeting Room",
                    Content = "Sophisticated design combining functionality with aesthetics. Premium materials and cutting-edge technology.",
                    ImagePath = "/images/portfolio3.jpg",
                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new PageSection
                {
                    SectionType = "About",
                    Title = "Discover more about iOTA",
                    Content = "Find out who we are, why we do it and why we love what we do.",
                    ImagePath = "/images/about.jpg",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            };

            _context.PageSections.AddRange(defaultSections);
            await _context.SaveChangesAsync();
        }
    }
}
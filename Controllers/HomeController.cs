using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VertoDevTest.Data;

namespace VertoDevTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var sections = await _db.PageSections
                .Include(s => s.MediaItem)
                .OrderBy(s => s.SortOrder)
                .ToListAsync();

            return View(sections);
        }
    }
}
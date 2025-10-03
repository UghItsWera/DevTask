using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VertoDevTest.Data;
using VertoDevTest.Models;

namespace VertoDevTest.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public AdminController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        // List items
        public async Task<IActionResult> Index()
        {
            var list = await _db.PageSections.Include(p => p.MediaItem).OrderBy(p => p.SortOrder).ToListAsync();
            return View(list);
        }

        // Create GET
        public IActionResult Create() => View();

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PageSection model, IFormFile imageFile)
        {
            if (!ModelState.IsValid) return View(model);

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploads);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var media = new MediaItem
                {
                    FileName = fileName,
                    ContentType = imageFile.ContentType,
                    Url = $"/uploads/{fileName}",
                    AltText = model.Title
                };

                _db.MediaItems.Add(media);
                await _db.SaveChangesAsync();

                model.MediaItemId = media.Id;
            }

            _db.PageSections.Add(model);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Edit GET
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _db.PageSections.Include(p => p.MediaItem).FirstOrDefaultAsync(p => p.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PageSection model, IFormFile imageFile)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            var existing = await _db.PageSections.Include(p => p.MediaItem).FirstOrDefaultAsync(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.Title = model.Title;
            existing.Body = model.Body;
            existing.HtmlTag = model.HtmlTag;
            existing.SortOrder = model.SortOrder;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploads);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var media = new MediaItem
                {
                    FileName = fileName,
                    ContentType = imageFile.ContentType,
                    Url = $"/uploads/{fileName}",
                    AltText = model.Title
                };

                _db.MediaItems.Add(media);
                await _db.SaveChangesAsync();

                existing.MediaItemId = media.Id;
            }

            _db.PageSections.Update(existing);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Delete GET
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.PageSections.Include(p => p.MediaItem).FirstOrDefaultAsync(p => p.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _db.PageSections.FindAsync(id);
            if (item != null)
            {
                _db.PageSections.Remove(item);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
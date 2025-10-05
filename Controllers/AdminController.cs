using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VertoDevTest.Data;
using VertoDevTest.Models;

namespace VertoDevTest.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var sections = await _context.PageSections
                .OrderBy(s => s.DisplayOrder)
                .ToListAsync();
            return View(sections);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PageSection pageSection, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "uploads");
                    
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    pageSection.ImagePath = "/images/uploads/" + uniqueFileName;
                }

                pageSection.CreatedDate = DateTime.Now;
                _context.Add(pageSection);
                await _context.SaveChangesAsync();
                
                TempData["SuccessMessage"] = "Section created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(pageSection);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageSection = await _context.PageSections.FindAsync(id);
            if (pageSection == null)
            {
                return NotFound();
            }
            return View(pageSection);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PageSection pageSection, IFormFile? ImageFile)
        {
            if (id != pageSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Handle image upload
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        // Delete old image if exists
                        if (!string.IsNullOrEmpty(pageSection.ImagePath))
                        {
                            var oldImagePath = Path.Combine(_environment.WebRootPath, pageSection.ImagePath.TrimStart('/'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "uploads");
                        
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(fileStream);
                        }

                        pageSection.ImagePath = "/images/uploads/" + uniqueFileName;
                    }

                    pageSection.ModifiedDate = DateTime.Now;
                    _context.Update(pageSection);
                    await _context.SaveChangesAsync();
                    
                    TempData["SuccessMessage"] = "Section updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageSectionExists(pageSection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pageSection);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageSection = await _context.PageSections
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (pageSection == null)
            {
                return NotFound();
            }

            return View(pageSection);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pageSection = await _context.PageSections.FindAsync(id);
            
            if (pageSection != null)
            {
                // Delete associated image file if exists
                if (!string.IsNullOrEmpty(pageSection.ImagePath))
                {
                    var imagePath = Path.Combine(_environment.WebRootPath, pageSection.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.PageSections.Remove(pageSection);
                await _context.SaveChangesAsync();
                
                TempData["SuccessMessage"] = "Section deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PageSectionExists(int id)
        {
            return _context.PageSections.Any(e => e.Id == id);
        }
    }
}
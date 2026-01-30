using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCM.Data;
using PCM.Models;

namespace PCM.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var news = _context.News
                .Where(n => n.Status == "Published")
                .OrderByDescending(n => n.IsPinned)
                .ThenByDescending(n => n.CreatedDate)
                .ToList();

            return View(news);
        }

        public IActionResult Details(int id)
        {
            var news = _context.News.FirstOrDefault(n => n.Id == id);
            if (news == null)
                return NotFound();

            return View(news);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(_999_News news)
        {
            if (ModelState.IsValid)
            {
                news.CreatedDate = DateTime.Now;
                news.CreatedBy = User.Identity?.Name ?? "System";
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var news = _context.News.Find(id);
            if (news == null)
                return NotFound();
            return View(news);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, _999_News news)
        {
            if (id != news.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    news.UpdatedDate = DateTime.Now;
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.News.Any(e => e.Id == id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var news = _context.News.Find(id);
            if (news != null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

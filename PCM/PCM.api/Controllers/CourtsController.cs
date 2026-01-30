using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCM.Data;
using PCM.Models;

namespace PCM.Controllers
{
    public class CourtsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CourtsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // =========================
        // DANH SÁCH
        // =========================
        public IActionResult Index()
        {
            var data = _db.Courts.ToList();
            return View(data);
        }

        // =========================
        // FORM TẠO
        // =========================
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // LƯU TẠO
        // =========================
        [HttpPost]
        public IActionResult Create(_999_Court court)
        {
            if (ModelState.IsValid)
            {
                var maxNumber = _db.Courts.Any() ? _db.Courts.Max(c => c.Number) : 0;
                court.Number = maxNumber + 1;
                court.IsActive = true;
                _db.Courts.Add(court);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(court);
        }

        // =========================
        // FORM SỬA
        // =========================
        public IActionResult Edit(int id)
        {
            var court = _db.Courts.Find(id);
            if (court == null) return NotFound();
            return View(court);
        }

        // =========================
        // LƯU SỬA
        // =========================
        [HttpPost]
        public IActionResult Edit(_999_Court court)
        {
            if (ModelState.IsValid)
            {
                _db.Courts.Update(court);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(court);
        }

        // =========================
        // XÓA
        // =========================
        public IActionResult Delete(int id)
        {
            var court = _db.Courts.Find(id);
            if (court == null) return NotFound();
            _db.Courts.Remove(court);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
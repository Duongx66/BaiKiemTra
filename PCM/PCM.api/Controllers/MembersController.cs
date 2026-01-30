using Microsoft.AspNetCore.Mvc;
using PCM.Data;
using PCM.Models;

namespace PCM.Controllers
{
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MembersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // =========================
        // DANH SÁCH
        // =========================
        public IActionResult Index()
        {
            var data = _db.Members.ToList();
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
        public IActionResult Create(_999_Member member)
        {
            if (ModelState.IsValid)
            {
                _db.Members.Add(member);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // =========================
        // FORM SỬA
        // =========================
        public IActionResult Edit(int id)
        {
            var member = _db.Members.Find(id);
            if (member == null) return NotFound();
            return View(member);
        }

        // =========================
        // LƯU SỬA
        // =========================
        [HttpPost]
        public IActionResult Edit(_999_Member member)
        {
            if (ModelState.IsValid)
            {
                _db.Members.Update(member);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // =========================
        // XÓA
        // =========================
        public IActionResult Delete(int id)
        {
            var member = _db.Members.Find(id);
            if (member == null) return NotFound();
            _db.Members.Remove(member);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
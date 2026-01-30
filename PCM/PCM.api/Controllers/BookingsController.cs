using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCM.Data;
using PCM.Models;

namespace PCM.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookingsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // =========================
        // DANH SÁCH
        // =========================
     public IActionResult Index()
{
var data = _db.Bookings
    .Include(b => b.Court)
    .Include(b => b.Member)
    .ToList();


    return View(data);
}

        // =========================
        // FORM TẠO
        // =========================
        public IActionResult Create()
        {
            ViewBag.Courts = _db.Courts.ToList();
            ViewBag.Members = _db.Members.ToList();
            return View();
        }

        // =========================
        // LƯU
        // =========================
        [HttpPost]
        public IActionResult Create(string courtName, string memberName, DateTime bookingDate, int startHour, int endHour)
        {
            // Tìm hoặc tạo sân
            var court = _db.Courts.FirstOrDefault(c => c.CourtName == courtName);
            if (court == null)
            {
                var maxNumber = _db.Courts.Any() ? _db.Courts.Max(c => c.Number) : 0;
                court = new _999_Court { CourtName = courtName, Number = maxNumber + 1, IsActive = true };
                _db.Courts.Add(court);
                _db.SaveChanges();
            }

            // Tìm hoặc tạo hội viên
            var member = _db.Members.FirstOrDefault(m => m.FullName == memberName);
            if (member == null)
            {
                member = new _999_Member { FullName = memberName, JoinDate = DateTime.UtcNow };
                _db.Members.Add(member);
                _db.SaveChanges();
            }

            // Kiểm tra trùng lịch
            bool isConflict = _db.Bookings.Any(b =>
                b.CourtId == court.Id &&
                b.BookingDate.Date == bookingDate.Date &&
                (
                    (startHour >= b.StartHour && startHour < b.EndHour) ||
                    (endHour > b.StartHour && endHour <= b.EndHour)
                )
            );

            if (isConflict)
            {
                ViewBag.Error = "❌ Trùng lịch sân!";
                return View();
            }

            var booking = new _999_Booking
            {
                CourtId = court.Id,
                MemberId = member.Id,
                BookingDate = bookingDate,
                StartHour = startHour,
                EndHour = endHour
            };

            _db.Bookings.Add(booking);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

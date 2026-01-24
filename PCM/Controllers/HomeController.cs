using Microsoft.AspNetCore.Mvc;
using PCM.Data;

namespace PCM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.CourtCount = _context.Courts.Count();
            ViewBag.MemberCount = _context.Members.Count();
            ViewBag.BookingCount = _context.Bookings.Count();
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.api.Data;

namespace PCM.api.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // If user is logged in, redirect to dashboard
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.CourtCount = _context.Courts.Count();
            ViewBag.MemberCount = _context.Members.Count();
            ViewBag.BookingCount = _context.Bookings.Count();
            return View();
        }
    }
}

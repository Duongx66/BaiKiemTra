using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCM.Data;
using PCM.Models;

namespace PCM.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard statistics
            ViewBag.TotalCourts = _context.Courts.Count();
            ViewBag.TotalMembers = _context.Members.Count();
            ViewBag.TotalBookings = _context.Bookings.Count();
            ViewBag.TotalMatches = _context.Matches.Count();

            // Recent bookings
            var recentBookings = _context.Bookings
                .Include(b => b.Court)
                .Include(b => b.Member)
                .OrderByDescending(b => b.BookingDate)
                .Take(5)
                .ToList();

            ViewBag.RecentBookings = recentBookings;

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            ViewBag.TotalCourts = _context.Courts.Count();
            ViewBag.TotalMembers = _context.Members.Count();
            ViewBag.TotalBookings = _context.Bookings.Count();
            ViewBag.TotalMatches = _context.Matches.Count();
            
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageCourts()
        {
            var courts = _context.Courts.ToList();
            return View(courts);
        }

        [Authorize(Roles = "Admin,Treasurer")]
        public IActionResult ManageFunds()
        {
            var transactions = _context.Transactions.ToList();
            ViewBag.TotalIncome = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            ViewBag.TotalExpense = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            ViewBag.Balance = ViewBag.TotalIncome - ViewBag.TotalExpense;
            return View();
        }

        public IActionResult Leaderboard()
        {
            var members = _context.Members
                .AsEnumerable()
                .OrderByDescending(m => m.WinRate)
                .ThenByDescending(m => m.MatchesPlayed)
                .Take(50)
                .ToList();

            return View(members);
        }
    }
}

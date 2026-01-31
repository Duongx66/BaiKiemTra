using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCM.api.Data;
using PCM.api.Models;

namespace PCM.api.Controllers
{
    [Authorize(Roles = "Admin,Treasurer")]
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? category, string? type)
        {
            var transactions = _context.Transactions
                .Include(t => t.Member)
                .OrderByDescending(t => t.TransactionDate)
                .AsEnumerable();

            if (!string.IsNullOrEmpty(category))
            {
                transactions = transactions.Where(t => t.Category == category);
            }

            if (!string.IsNullOrEmpty(type))
            {
                transactions = transactions.Where(t => t.Type == type);
            }

            return View(transactions.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Members = _context.Members.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(_999_Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.TransactionDate = DateTime.Now;
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Members = _context.Members.ToList();
            return View(transaction);
        }

        public IActionResult Report()
        {
            var transactions = _context.Transactions
                .Include(t => t.Member)
                .OrderByDescending(t => t.TransactionDate)
                .ToList();

            var summary = new
            {
                TotalIncome = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount),
                TotalExpense = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount),
                Balance = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount) -
                         transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount),
                TransactionCount = transactions.Count
            };

            ViewBag.Summary = summary;
            return View(transactions);
        }
    }
}

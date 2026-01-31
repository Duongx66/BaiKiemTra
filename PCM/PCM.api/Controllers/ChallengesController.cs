using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCM.api.Data;
using PCM.api.Models;

namespace PCM.api.Controllers
{
    [Authorize]
    public class ChallengesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChallengesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? status)
        {
            var challenges = _context.Challenges
                .Include(c => c.Participants)
                .ThenInclude(p => p.Member)
                .OrderByDescending(c => c.StartDate)
                .AsEnumerable();

            if (!string.IsNullOrEmpty(status?.ToString()))
            {
                challenges = challenges.Where(c => c.Status == status.ToString());
            }

            return View(challenges.ToList());
        }

        public IActionResult Details(int id)
        {
            var challenge = _context.Challenges
                .Include(c => c.Participants)
                .ThenInclude(p => p.Member)
                .FirstOrDefault(c => c.Id == id);

            if (challenge == null)
                return NotFound();

            return View(challenge);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(_999_Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(challenge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(challenge);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var challenge = _context.Challenges.Find(id);
            if (challenge == null)
                return NotFound();
            return View(challenge);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, _999_Challenge challenge)
        {
            if (id != challenge.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(challenge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Challenges.Any(e => e.Id == id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(challenge);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Join(int id)
        {
            var challenge = _context.Challenges.Find(id);
            if (challenge == null)
                return NotFound();

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var member = _context.Members.FirstOrDefault(m => m.IdentityUserId == userId);

            if (member == null)
                return Unauthorized();

            // Check if already joined
            if (_context.Participants.Any(p => p.ChallengeId == id && p.MemberId == member.Id))
            {
                return BadRequest("Bạn đã tham gia giải đấu này.");
            }

            var participant = new _999_Participant
            {
                ChallengeId = id,
                MemberId = member.Id,
                JoinedDate = DateTime.Now,
                Status = "Registered"
            };

            _context.Participants.Add(participant);
            challenge.CurrentParticipants++;
            
            _context.Update(challenge);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}

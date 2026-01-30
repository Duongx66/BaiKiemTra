using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCM.Data;
using PCM.Models;

namespace PCM.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MatchesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // =========================
        // DANH SÁCH
        // =========================
        public IActionResult Index()
        {
            var data = _db.Matches
                .Include(m => m.Court)
                .Include(m => m.Player1)
                .Include(m => m.Player2)
                .Include(m => m.Player3)
                .Include(m => m.Player4)
                .OrderByDescending(m => m.MatchDate)
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
        // LƯU TẠO
        // =========================
        [HttpPost]
        public IActionResult Create(_999_Match match)
        {
            // Validate Player IDs
            if (match.Player1Id == match.Player2Id && match.Player1Id > 0)
            {
                ModelState.AddModelError("", "Người chơi 1 và Người chơi 2 phải khác nhau");
            }

            if (match.MatchType == "Doubles")
            {
                if (match.Player3Id == null || match.Player4Id == null)
                {
                    ModelState.AddModelError("", "Vui lòng chọn đủ 4 người chơi cho trận Doubles");
                }
                else if (match.Player3Id == match.Player4Id)
                {
                    ModelState.AddModelError("", "Người chơi 3 và Người chơi 4 phải khác nhau");
                }
            }

            if (ModelState.IsValid)
            {
                match.CreatedAt = DateTime.UtcNow;
                _db.Matches.Add(match);
                _db.SaveChanges();

                // Cập nhật số trận đấu cho hội viên
                UpdateMemberStats(match);

                return RedirectToAction("Index");
            }
            ViewBag.Courts = _db.Courts.ToList();
            ViewBag.Members = _db.Members.ToList();
            return View(match);
        }

        // =========================
        // FORM SỬA
        // =========================
        public IActionResult Edit(int id)
        {
            var match = _db.Matches.Find(id);
            if (match == null) return NotFound();
            ViewBag.Courts = _db.Courts.ToList();
            ViewBag.Members = _db.Members.ToList();
            return View(match);
        }

        // =========================
        // LƯU SỬA
        // =========================
        [HttpPost]
        public IActionResult Edit(_999_Match match)
        {
            // Validate Player IDs
            if (match.Player1Id == match.Player2Id && match.Player1Id > 0)
            {
                ModelState.AddModelError("", "Người chơi 1 và Người chơi 2 phải khác nhau");
            }

            if (match.MatchType == "Doubles")
            {
                if (match.Player3Id == null || match.Player4Id == null)
                {
                    ModelState.AddModelError("", "Vui lòng chọn đủ 4 người chơi cho trận Doubles");
                }
                else if (match.Player3Id == match.Player4Id)
                {
                    ModelState.AddModelError("", "Người chơi 3 và Người chơi 4 phải khác nhau");
                }
            }

            if (ModelState.IsValid)
            {
                var existingMatch = _db.Matches.Find(match.Id);
                if (existingMatch == null) return NotFound();

                existingMatch.MatchDate = match.MatchDate;
                existingMatch.CourtId = match.CourtId;
                existingMatch.MatchType = match.MatchType;
                existingMatch.Player1Id = match.Player1Id;
                existingMatch.Player2Id = match.Player2Id;
                existingMatch.Player3Id = match.Player3Id;
                existingMatch.Player4Id = match.Player4Id;
                existingMatch.WinnerId = match.WinnerId;
                existingMatch.WinnerTeam = match.WinnerTeam;
                existingMatch.Status = match.Status;
                existingMatch.IsRanked = match.IsRanked;
                existingMatch.Notes = match.Notes;
                existingMatch.UpdatedAt = DateTime.UtcNow;

                _db.Matches.Update(existingMatch);
                _db.SaveChanges();
                
                UpdateMemberStats(existingMatch);

                return RedirectToAction("Index");
            }
            ViewBag.Courts = _db.Courts.ToList();
            ViewBag.Members = _db.Members.ToList();
            return View(match);
        }

        // =========================
        // XÓA
        // =========================
        public IActionResult Delete(int id)
        {
            var match = _db.Matches.Find(id);
            if (match == null) return NotFound();
            _db.Matches.Remove(match);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // =========================
        // HELPER: Cập nhật thống kê hội viên
        // =========================
        private void UpdateMemberStats(_999_Match match)
        {
            if (match.Status != "Completed" || match.WinnerId == null)
                return;

            // Single match
            if (match.MatchType == "Single")
            {
                var player1 = _db.Members.Find(match.Player1Id);
                var player2 = _db.Members.Find(match.Player2Id);

                if (player1 != null) player1.MatchesPlayed++;
                if (player2 != null) player2.MatchesPlayed++;

                if (player1?.Id == match.WinnerId && player1 != null)
                {
                    player1.MatchesWon++;
                    if (player2 != null) player2.MatchesLost++;
                }
                else if (player2?.Id == match.WinnerId && player2 != null)
                {
                    player2.MatchesWon++;
                    if (player1 != null) player1.MatchesLost++;
                }

                _db.SaveChanges();
            }
            // Doubles match
            else if (match.MatchType == "Doubles")
            {
                var players = new[] { match.Player1Id, match.Player2Id, match.Player3Id, match.Player4Id }
                    .Where(p => p.HasValue)
                    .Select(p => _db.Members.Find(p!.Value))
                    .Where(p => p != null)
                    .ToList();

                foreach (var player in players)
                {
                    if (player != null)
                        player.MatchesPlayed++;
                }

                _db.SaveChanges();
            }
        }
    }
}

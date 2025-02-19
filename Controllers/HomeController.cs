using AetherCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AetherCore.Data;
using AetherCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AetherCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string searchQuery)
        {
            var users = _db.Hyesosi.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                users = users.Where(u => u.Name.Contains(searchQuery));
            }

            var userList = users.ToList();

            foreach (var user in userList)
            {
                var grades = _db.Otsivi
                    .Where(o => o.Id_Prepod == user.Id_Prepod)
                    .Select(o => o.Grade)
                    .ToList();

                user.GradeO = Convert.ToDouble(grades.Any() ? Math.Round(grades.Average(), 1) : 0.0);
            }

            return View(userList);
        }
        public IActionResult Details(int id)
        {
            var user = _db.Hyesosi
                .Include(u => u.FeedBacks)
                .FirstOrDefault(u => u.Id_Prepod == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult SubmitFeedback(int userId, string comment, int grade)
        {
            var feedback = new FeedBack
            {
                Text = comment,
                Id_Prepod = userId,
                Grade = grade
            };

            _db.Otsivi.Add(feedback);
            _db.SaveChanges();

            return RedirectToAction("Details", new { id = userId });
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
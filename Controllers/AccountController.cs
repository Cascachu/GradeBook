using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Utils;
using GradeBook.Services;

namespace GradeBook.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(string Email, string Password, string Role)
        {
            var users = UserJsonService.LoadUsers();
            if (users.Any(u => u.Email == Email))
            {
                ViewBag.Error = "Email already exists.";
                return View(new User { Email = Email, Role = Role });
            }

            var user = new User
            {
                Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
                Email = Email,
                PasswordHash = PasswordHelper.HashPassword(Password),
                Role = Role
            };
            users.Add(user);
            UserJsonService.SaveUsers(users);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            var users = UserJsonService.LoadUsers();
            var hash = PasswordHelper.HashPassword(Password);
            var user = users.FirstOrDefault(u => u.Email == Email && u.PasswordHash == hash);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "Students");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
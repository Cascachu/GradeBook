using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Data;
using GradeBook.Utils;

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
        public IActionResult Register(string Username, string Password, string Role)
        {
            var users = UserStore.LoadUsers();
            if (users.Any(u => u.Username == Username))
            {
                ViewBag.Error = "Username already exists.";
                return View(new User { Username = Username, Role = Role });
            }

            var user = new User
            {
                Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
                Username = Username,
                PasswordHash = PasswordHelper.HashPassword(Password),
                Role = Role
            };
            users.Add(user);
            UserStore.SaveUsers(users);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var users = UserStore.LoadUsers();
            var hash = PasswordHelper.HashPassword(Password);
            var user = users.FirstOrDefault(u => u.Username == Username && u.PasswordHash == hash);

            if (user == null)
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }

            HttpContext.Session.SetString("Username", user.Username);
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
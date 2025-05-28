using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Services;

namespace GradeBook.Controllers
{
    public class ManagersController : Controller
    {
        [HttpGet]
        public IActionResult ManageAccounts()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Manager")
            {
                return RedirectToAction("TeacherMain", "Students"); 
            }

            var students = new StudentJsonService().GetStudents();
            var users = UserJsonService.LoadUsers();
            
            return View(new Tuple<List<Student>, List<User>>(students, users));
        }

        [HttpPost]
        public IActionResult AssignStudentId(int userId, int? studentId)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Manager")
            {
                return RedirectToAction("TeacherMain", "Students");
            }

            var users = UserJsonService.LoadUsers();
            var user = users.FirstOrDefault(u => u.Id == userId && u.Role == "Student");
            if (user != null)
            {
                user.StudentId = studentId;
                UserJsonService.SaveUsers(users);
            }
            return RedirectToAction("ManageAccounts", "Managers");
        }

        [HttpPost]
        public IActionResult AssignRole(int userId, string role)
        {
            var currentRole = HttpContext.Session.GetString("Role");
            if (currentRole != "Manager")
            {
                return RedirectToAction("TeacherMain", "Students");
            }

            var users = UserJsonService.LoadUsers();
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.Role = role;
                UserJsonService.SaveUsers(users);
            }
            return RedirectToAction("ManageAccounts", "Managers");
        }

        [HttpGet]
        public IActionResult RemoveAccount(int userId)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Manager")
            {
                return RedirectToAction("TeacherMain", "Students");
            }

            var users = UserJsonService.LoadUsers();
            var user = users.FirstOrDefault(u => u.Id == userId);
            
            if (user == null)
                return NotFound();
            
            if (user.Role == "Manager")
            {
                TempData["ErrorMessage"] = "Manager accounts cannot be removed.";
                return RedirectToAction("ManageAccounts");
            }
            
            users.Remove(user);
            UserJsonService.SaveUsers(users);
            TempData["SuccessMessage"] = $"Account {user.Email} has been successfully removed.";
            
            return RedirectToAction("ManageAccounts");
        }
    }
}
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
                return RedirectToAction("Index", "Students");
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
                return RedirectToAction("Index", "Students");
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
    }
}
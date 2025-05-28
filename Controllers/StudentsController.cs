using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Services;
using System.Linq;

namespace GradeBook.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentJsonService _jsonDataService;

        public StudentsController(StudentJsonService jsonDataService)
        {
            _jsonDataService = jsonDataService;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Student")
            {
                return RedirectToAction("StudentMain");
            }
            
            return RedirectToAction("TeacherMain");
        }

        public IActionResult StudentMain()
        {
            return View();
        }

        public IActionResult TeacherMain()
        {
            var students = _jsonDataService.GetStudents();
            var classes = students.Select(s => s.Class.ToString()).Distinct().OrderBy(c => c).ToList();
            return View("~/Views/TeacherMain.cshtml", classes);
        }

        public IActionResult DisplayClass(string className)
        {
            var students = _jsonDataService.GetStudents().Where(s => s.Class.ToString() == className).ToList();
            ViewBag.ClassName = className;
            return View(students);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var students = _jsonDataService.GetStudents();
            student.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            _jsonDataService.SaveStudents(students);
            return RedirectToAction("TeacherMain"); 
        }
    }
}

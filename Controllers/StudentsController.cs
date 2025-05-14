using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Services;

namespace GradeBook.Controllers
{
    public class StudentsController : Controller
    {
        private readonly JsonDataService _jsonDataService;

        public StudentsController(JsonDataService jsonDataService)
        {
            _jsonDataService = jsonDataService;
        }

        public IActionResult Index()
        {
            var students = _jsonDataService.GetStudents();
            return View("~/Views/Index.cshtml", students);
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
            return RedirectToAction("Index");
        }
    }
}

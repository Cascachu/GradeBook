using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Services;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook.Controllers
{
    public class GradesController : Controller
    {
        private readonly JsonDataService _jsonDataService;

        public GradesController(JsonDataService jsonDataService)
        {
            _jsonDataService = jsonDataService;
        }

        public IActionResult AddGrade(int studentId)
        {
            var grade = new Grade { StudentId = studentId };
            return View(grade);
        }

        [HttpPost]
        public IActionResult AddGrade(Grade grade)
        {
            var students = _jsonDataService.GetStudents();
            var student = students.FirstOrDefault(s => s.Id == grade.StudentId);
            if (student == null)
                return NotFound();

            grade.Id = student.Grades.Any() ? student.Grades.Max(g => g.Id) + 1 : 1;
            student.Grades.Add(grade);
            _jsonDataService.SaveStudents(students);

            return RedirectToAction("Index", "Students");
        }

        public IActionResult EditGrades(int studentId)
        {
            var student = _jsonDataService.GetStudents().FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                return NotFound();

            student.Grades ??= new List<Grade>();
            return View(student);
        }

        
    }
}

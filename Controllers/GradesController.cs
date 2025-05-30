using Microsoft.AspNetCore.Mvc;
using GradeBook.Models;
using GradeBook.Services;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace GradeBook.Controllers
{
    public class GradesController : Controller
    {
        private readonly StudentJsonService _jsonDataService;

        public GradesController(StudentJsonService jsonDataService)
        {
            _jsonDataService = jsonDataService;
        }

        public IActionResult AddGrade(int studentId)
        {
            if (HttpContext.Session.GetString("Role") != "Teacher")
                return Forbid();
            var grade = new Grade { StudentId = studentId };
            return View(grade);
        }

        [HttpPost]
        public IActionResult AddGrade(Grade grade)
        {
            if (HttpContext.Session.GetString("Role") != "Teacher")
                return Forbid();

            var students = _jsonDataService.GetStudents();
            var student = students.FirstOrDefault(s => s.Id == grade.StudentId);
            if (student == null)
                return NotFound();

            grade.Id = student.Grades.Any() ? student.Grades.Max(g => g.Id) + 1 : 1;
            student.Grades.Add(grade);
            _jsonDataService.SaveStudents(students);

            return RedirectToAction("DisplayGrades", new { studentId = grade.StudentId });
        }

        public IActionResult DisplayGrades(int studentId)
        {
            var student = _jsonDataService.GetStudents().FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                return NotFound();

            student.Grades ??= new List<Grade>();
            return View("DisplayGrades", student);
        }

        public IActionResult EditGrade(int studentId, int gradeId)
        {
            if (HttpContext.Session.GetString("Role") != "Teacher")
                return Forbid();

            var student = _jsonDataService.GetStudents().FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                return NotFound();

            var grade = student.Grades?.FirstOrDefault(g => g.Id == gradeId);
            if (grade == null)
                return NotFound();

            return View(grade);
        }

        [HttpPost]
        public IActionResult EditGrade(Grade grade)
        {
            if (HttpContext.Session.GetString("Role") != "Teacher")
                return Forbid();

            var students = _jsonDataService.GetStudents();
            var student = students.FirstOrDefault(s => s.Id == grade.StudentId);
            if (student == null)
                return NotFound();

            var existingGrade = student.Grades.FirstOrDefault(g => g.Id == grade.Id);
            if (existingGrade == null)
                return NotFound();

            existingGrade.Subject = grade.Subject;
            existingGrade.GradeValue = grade.GradeValue;
            existingGrade.Date = grade.Date;
            existingGrade.Description = grade.Description;

            _jsonDataService.SaveStudents(students);

            return RedirectToAction("DisplayGrades", new { studentId = grade.StudentId });
        }

        public IActionResult DeleteGrade(int studentId, int gradeId)
        {
            if (HttpContext.Session.GetString("Role") != "Teacher")
                return Forbid();

            var students = _jsonDataService.GetStudents();
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                return NotFound();

            var grade = student.Grades?.FirstOrDefault(g => g.Id == gradeId);
            if (grade == null)
                return NotFound();

            student.Grades.Remove(grade);
            _jsonDataService.SaveStudents(students);

            return RedirectToAction("DisplayGrades", new { studentId = studentId });
        }
    }
}

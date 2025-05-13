using System.Diagnostics;

namespace GradeBook.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}

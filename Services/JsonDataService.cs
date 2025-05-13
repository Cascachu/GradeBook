using System.Text.Json;
using GradeBook.Models;

namespace GradeBook.Services
{
    
    

    public class JsonDataService
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "students.json");

        public List<Student> GetStudents()
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(jsonData) ?? new List<Student>();
        }

        public void SaveStudents(List<Student> students)
        {
            var jsonData = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }
    }
}

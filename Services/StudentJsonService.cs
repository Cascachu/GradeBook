using System.Text.Json;
using System.Text.Json.Serialization;
using GradeBook.Models;

namespace GradeBook.Services
{
    
    

public class StudentJsonService
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "students.json");

        public List<Student> GetStudents()
        {
            var jsonData = File.ReadAllText(_filePath);
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<List<Student>>(jsonData, options) ?? new List<Student>();
        }

        public void SaveStudents(List<Student> students)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter()); 

            var jsonData = JsonSerializer.Serialize(students, options);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}

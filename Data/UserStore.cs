using System.Text.Json;
using GradeBook.Models;

namespace GradeBook.Data
{
    public static class UserStore
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.json");

        public static List<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new List<User>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public static void SaveUsers(List<User> users)
        {
            var directory = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
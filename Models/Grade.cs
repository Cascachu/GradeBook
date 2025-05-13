namespace GradeBook.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int GradeValue { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int StudentId { get; set; }
    }
}

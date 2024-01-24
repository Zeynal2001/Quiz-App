namespace Quiz_App.Models
{
    public class Quizzes
    {
        public int QuizId { get; set; }
        public string? Description { get; set; }
        public string QuizTitle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CategoryId { get; set; }
    }
}

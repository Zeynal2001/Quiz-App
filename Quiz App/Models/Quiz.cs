namespace Quiz_App.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CategoryId { get; set; }
        public string QuizTitle { get; set; }

        public override string ToString()
        {
            return $"{QuizId} || {QuizName} || {Description} || {StartTime} || {EndTime} || {CategoryId} || {QuizTitle}";
        }
    }
}

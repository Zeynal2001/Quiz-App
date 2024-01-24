namespace Quiz_App.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int QuizId { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public int TotalScore { get; set; }
    }
}

namespace Quiz_App.Models
{
    public class Answers
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public string UserChoise { get; set; }
        public int UserId { get; set; }

    }
}

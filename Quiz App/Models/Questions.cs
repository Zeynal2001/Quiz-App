namespace Quiz_App.Models
{
    public class Questions
    {
        public int QuestionId { get; set; }
        public bool CorrectOption { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int QuizId { get; set; }
    }
}

namespace Quiz_App.Models
{
    public class Questions
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int CorrectOption { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int QuizId { get; set; }


        public override string ToString()
        {
            return $"{QuestionId}  ||  {QuestionText}  ||  {CorrectOption}  ||  {OptionA}  ||  {OptionB}  ||  {OptionC}  ||  {OptionD} ||  {QuizId}  ||";
        }
    }
}

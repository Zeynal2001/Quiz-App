using Quiz_App.DataTransferObject;
using Quiz_App.Enums;
using Quiz_App.Extensions;
using Quiz_App.Models;
using Quiz_App.SELECTMethods;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace Quiz_App.Operating_Methods
{
    public class ForUser
    {

        public static async Task StartQuizAsync(SqlConnection conn, int userId)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            //TODO:Oxunaqligi artirmaq ucun Quizin sutunlarini azalt
            Console.WriteLine("QuizID       ||       QuizName        ||         CategoryID      ||        QuizTtle       ||");
            QuizQuestionAndAnswerCrud.GetQuizzes2(conn).ForEach(q =>
            {
                Console.WriteLine(q);
            });

            Console.WriteLine("\n-----------------------------------");
            ConsoleExtensions.PrintMessage("Xaiş edirik aşağıda başlamaq istədiyiniz quizin ID sini daxil edin: ", MessageType.Info);
            int quizId = InputExtensions.GetInt();


            var questions = QuizQuestionAndAnswerCrud.GetQuestionsByQuizId(conn, quizId);

            var answers = new List<Answer>();
            var counter = 1;


            var quiz = GetQuizById(conn, quizId);
            var startTime = DateTime.Now;

            foreach (var question in questions)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine($"{counter}) {question.QuestionText}");
                Console.WriteLine($"A) {question.OptionA}");
                Console.WriteLine($"B) {question.OptionB}");
                Console.WriteLine($"C) {question.OptionC}");
                Console.WriteLine($"D) {question.OptionD}");
                counter++;
                Console.WriteLine("Düzgün variantı daxil edin: (A,B,C,D)");
                string usercorrectOption = InputExtensions.GetNonNullString();
               
                if (question.CorrectOption == usercorrectOption)
                {
                    ConsoleExtensions.PrintMessage("Təbriklər düzgün cavab verdiniz. Total xalınız: ", MessageType.Success);
                    answers.Add(new()
                    {
                        IsCorrect = true,
                        QuestionId = question.QuestionId,
                        UserChoise = usercorrectOption,
                        UserId = userId
                    });
                }
                else
                {
                    ConsoleExtensions.PrintMessage("Cavab düzgün deyil vəya başqa bir xəta baş verdi 😕", MessageType.Error);
                    answers.Add(new()
                    {
                        IsCorrect = false,
                        QuestionId = question.QuestionId,
                        UserChoise = usercorrectOption,
                        UserId = userId
                    });
                }
                if ((DateTime.Now - startTime).Minutes == quiz.EndTime)
                {
                    ConsoleExtensions.PrintMessage("Quizin bitdi", MessageType.Info);
                    break;  
                }


                //answers.Add(new()
                //{
                //    IsCorrect = (question.CorrectOption == usercorrectOption),
                //    QuestionId = question.QuestionId,
                //    UserChoise = usercorrectOption,
                //    UserId = userId,
                //    AnswerText = null
                //});
            }
            //TODO: Answerə insert elemek

            var cmd = conn.CreateCommand();

            var sqlanswerInsert = "INSERT INTO Answers(UserChoise, IsCorrect, QuestionId, UserId) values(@Puserchoise, @Piscorrect, @PquestionId, @PUserId)";

            var setirSayi = 0;
            foreach (var answer in answers)
            {

                cmd.CommandText = sqlanswerInsert;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Puserchoise", answer.UserChoise);
                cmd.Parameters.AddWithValue("@Piscorrect", answer.IsCorrect);
                cmd.Parameters.AddWithValue("@PquestionId", answer.QuestionId);
                cmd.Parameters.AddWithValue("@PUserId", answer.UserId);

                setirSayi += cmd.ExecuteNonQuery();
            }

            var dogrucavabSayi = answers.Where(a => a.IsCorrect).Count();
            var yanliscavabSayi = answers.Where(a => !a.IsCorrect).Count();
            if (setirSayi > 0)
            {
                var score = new Score()
                {
                    QuizId = quizId,
                    UserId = userId,
                    CorrectAnswers = dogrucavabSayi,
                    IncorrectAnswers = yanliscavabSayi,
                    //IncorrectAnswers = answers.Where(a => a.IsCorrect == false).Count(),
                };
                score.TotalScore = score.CorrectAnswers * 10;

                var selectQuery = "SELECT * FROM Score WHERE QuizID = @PquizId AND UserID = @PuserIdim ";

                cmd.CommandText = selectQuery;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PquizId", score.QuizId);
                cmd.Parameters.AddWithValue("@PuserIdim", score.UserId);

                var reader = cmd.ExecuteReader();
                var hasrows = reader.HasRows;
                reader.Close();
                if (hasrows)
                {
                    string updateQuery1 = "UPDATE Score SET CorrectAnswers = @CorrectAnswers, IncorrectAnswers = @IncorrectAnswers," +
                        " TotalScore = @TotalScore " +
                        "WHERE QuizID = @QuizID AND UserID = @UserID";

                    cmd.CommandText = updateQuery1;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CorrectAnswers", score.CorrectAnswers);
                    cmd.Parameters.AddWithValue("@IncorrectAnswers", score.IncorrectAnswers);
                    cmd.Parameters.AddWithValue("@TotalScore", score.TotalScore);
                    cmd.Parameters.AddWithValue("@QuizID", quizId);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    var setirsayi = cmd.ExecuteNonQuery();

                    if (setirSayi <= 0)
                    {
                        ConsoleExtensions.PrintMessage("Cavab düzgün deyil vəya başqa bir xəta baş verdi.", MessageType.Error);
                        //string updateQuery2 = "UPDATE Score SET IncorrectAnswers = @IncorrectAnswers, TotalScore = @TotalScore" +
                        //       "WHERE QuizID = @QuizID AND UserID = @UserID";
                    }
                }
                else
                {
                    string insertScore = "INSERT INTO Score (QuizID, UserID, CorrectAnswers, IncorrectAnswers, TotalScore) " +
                        "values(@PquizId, @PuserId, @PcorrectAnswers, @PincorrectAnswers, @PtotalScore)";

                    cmd.CommandText = insertScore;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PquizId", quizId);
                    cmd.Parameters.AddWithValue("@PuserId", userId);
                    cmd.Parameters.AddWithValue("@PcorrectAnswers", score.CorrectAnswers);
                    cmd.Parameters.AddWithValue("@PincorrectAnswers", score.IncorrectAnswers);
                    cmd.Parameters.AddWithValue("@PtotalScore", score.TotalScore);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Quiz GetQuizById(SqlConnection conn, int quizId)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var GetQuizById = "SELECT * FROM Quizzes WHERE QuizID = @Pquizid";

            var cmd = conn.CreateCommand();
            cmd.CommandText = GetQuizById;
            cmd.Parameters.AddWithValue("@Pquizid", quizId);

            var reader = cmd.ExecuteReader();

            var quiz = new Quiz();
            while (reader.Read())
            {

                quiz.QuizId = Convert.ToInt32(reader["QuizID"]);
                quiz.QuizName = Convert.ToString(reader["QuizName"]);
                quiz.Description = Convert.ToString(reader["DescriptionQ"]);
                DateTime.TryParse(reader["StartTime"].ToString(), out DateTime startDate);
                quiz.StartTime = startDate;
                quiz.EndTime = Convert.ToInt32(reader["EndTime"]);
                quiz.CategoryId = Convert.ToInt32(reader["CategoryID"]);
                quiz.QuizTitle = Convert.ToString(reader["QuizTitle"]);
            }

            reader.Close();
            return quiz;

        }
    }
}

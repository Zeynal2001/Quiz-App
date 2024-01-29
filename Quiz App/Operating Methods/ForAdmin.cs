using Quiz_App.Extensions;
using Quiz_App.SELECTMethods;
using System.Data;
using System.Data.SqlClient;

namespace Quiz_App.Operating_Methods
{
    public class ForAdmin
    {
        public static void AddQuizzes(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            //Console.WriteLine("Quizin daxil olduğu kateqoriyanı daxil edin:");
            //string kateqoriyaAd = InputExtensions.GetNonNullString();

            Console.WriteLine("Quiz adını daxil edin:");
            string name = InputExtensions.GetNonNullString();

            Console.WriteLine("Quiz başlığını daxil edin:");
            string title = InputExtensions.GetNonNullString();

            Console.WriteLine("Description u daxil edin:");
            string descriptionQ = InputExtensions.GetNonNullString();

            Console.WriteLine("Quizin kateqoriyasını aşağıda uyğun gələn rəqəm olaraq daxil edin:");
            Console.WriteLine("İngilis dili (1), Tarix (2), Proqramlaşdırma (3)");
            int categoryId = InputExtensions.GetInt();

            var sqlInsert = "INSERT INTO Quizzes(QuizName, DescriptionQ, StartTime, EndTime, CategoryID, QuizTitle) values(@PName, @PDescriptionQ, GETDATE(), NULL, @PCategoryid, @PTitle)";

            var cmd = conn.CreateCommand();
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@PName", name);
            cmd.Parameters.AddWithValue("@PTitle", title);
            cmd.Parameters.AddWithValue("@PDescriptionQ", descriptionQ);
            cmd.Parameters.AddWithValue("@PCategoryid", categoryId);

            var setirSayi = cmd.ExecuteNonQuery();

            if (setirSayi > 0)
                ConsoleExtensions.PrintMessage("Quiz uğurla yaradıldı ☑️", Enums.MessageType.Success);
            else
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);


            /*
            QuizName
            DescriptionQ
            StartTime 
            EndTime 
            CategoryID 
            QuizTtile
            */
        }

        public static void UpdateQuizzes(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            
            Console.WriteLine("QuizID       ||       QuizName        ||       DescriptionQ         ||      StartTime      ||       EndTime      ||      CategoryID      ||       QuizTitle");
            //var quizzes = QuizCrud.SelectQuizzes(conn);
            //foreach (var q in quizzes)
            //{
            //    Console.WriteLine(q);
            //}


            //var quizzes = QuizCrud.SelectQuizzes(conn);
            //quizzes.ForEach(Console.WriteLine);

            QuizCrud.SelectQuizzes(conn).ForEach(q =>
            {
                Console.WriteLine(q);
            });

            Console.WriteLine("\nAşağıda məlumatlarını dəyişmək istədiyiniz quizin ID sini daxil edin.");
            int quizId = InputExtensions.GetInt();

            /*
            UPDATE employees
            SET salary = 6000
            WHERE department_id = 1;
            */

            Console.WriteLine("Quiz adını daxil edin:");
            string updatedName = InputExtensions.GetNonNullString();

            Console.WriteLine("Quiz başlığını daxil edin:");
            string updatedTitle = InputExtensions.GetNonNullString();

            Console.WriteLine("Description u daxil edin:");
            string updatedDescriptionQ = InputExtensions.GetNonNullString();

            Console.WriteLine("Quizin kateqoriyasını aşağıda uyğun gələn rəqəm olaraq daxil edin:");
            Console.WriteLine("İngilis dili (1), Tarix (2), Proqramlaşdırma (3)");
            int updatedCategoryId = InputExtensions.GetInt();

            var sqlUpdate = "UPDATE  Quizzes SET QuizName = @PName, DescriptionQ = @PDescription, StartTime = GetDate(), EndTime = NULL, CategoryID = @PcatId, QuizTitle = @Ptitle WHERE QuizID = @PquizId";

            var cmd = conn.CreateCommand();
            cmd.CommandText = sqlUpdate;
            cmd.Parameters.AddWithValue("@PName", updatedName);
            cmd.Parameters.AddWithValue("@PDescription", updatedDescriptionQ);
            cmd.Parameters.AddWithValue("@PcatId", updatedCategoryId);
            cmd.Parameters.AddWithValue("@Ptitle", updatedTitle);
            cmd.Parameters.AddWithValue("@PquizId", quizId);

            var setirSayi = cmd.ExecuteNonQuery();

            if (setirSayi > 0)
            {
                ConsoleExtensions.PrintMessage("Məlumatlar uğurla dəyişdirildi 🤩", Enums.MessageType.Success);
            }
            else
            {
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);
            }
        }

        public static void RemoveQuizzes(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("QuizID       ||       QuizName        ||       DescriptionQ         ||      StartTime      ||       EndTime      ||      CategoryID      ||       QuizTitle");

            QuizCrud.SelectQuizzes(conn).ForEach(q =>
            {
                Console.WriteLine(q);
            });

            Console.WriteLine("\nAşağıda silmək istədiyiniz quizin ID sini daxil edin.");
            int removequizId = InputExtensions.GetInt();

            var sqlRemove = "DELETE FROM Quizzes WHERE QuizID = @PqId";

            var cmd = conn.CreateCommand();

            cmd.CommandText = sqlRemove;
            cmd.Parameters.AddWithValue("@PqId", removequizId);
            var setirSayi = cmd.ExecuteNonQuery();

            if (setirSayi > 0)
            {
                ConsoleExtensions.PrintMessage("Məlumatlar uğurla dəyişdirildi 🤩", Enums.MessageType.Success);
            }
            else
            {
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);
            }
        }

        public static void AddQuestions(SqlConnection conn)
        {

        }
    }
}

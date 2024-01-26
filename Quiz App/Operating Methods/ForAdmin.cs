using Quiz_App.Extensions;
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
    }
}

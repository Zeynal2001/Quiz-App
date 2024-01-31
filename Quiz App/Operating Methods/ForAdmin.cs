using Quiz_App.Extensions;
using Quiz_App.Models;
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

            QuizAndQuestionCrud.SelectQuizzes(conn).ForEach(q =>
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

            QuizAndQuestionCrud.SelectQuizzes(conn).ForEach(q =>
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
                ConsoleExtensions.PrintMessage("Quiz uğurla silindi ☑️", Enums.MessageType.Success);
            }
            else
            {
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);
            }
        }

        public static void AddQuestions(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("Sualın mətnini daxil edin:");
            string questionText = InputExtensions.GetNonNullString();

            Console.WriteLine("Sualın düzgün cavabını daxil edin: (A,B,C,D)");
            string correctOption = InputExtensions.GetNonNullString();

            Console.WriteLine("A) variantının mətnini daxil edin:");
            string optionA = InputExtensions.GetNonNullString();
            
            Console.WriteLine("B) variantının mətnini daxil edin:");
            string optionB = InputExtensions.GetNonNullString();

            Console.WriteLine("C) variantının mətnini daxil edin:");
            string optionC = InputExtensions.GetNonNullString();
            
            Console.WriteLine("D) variantının mətnini daxil edin:");
            string optionD = InputExtensions.GetNonNullString();
            
            Console.WriteLine("QuizID ni daxil edin(int olaraq):");
            int quizID = InputExtensions.GetInt();


            var sqlInsert = "INSERT INTO Questions(QuestionText, CorrectOption, OptionA, OptionB, OptionC, OptionD, QuizID) values(@PMetn, @PDuzgunSecim, @PSecimA, @PSecimB, @PSecimC, @PSecimD, @QuizId)";

            var cmd = conn.CreateCommand();
            cmd.CommandText = sqlInsert;
            cmd.Parameters.AddWithValue("@PMetn", questionText);
            cmd.Parameters.AddWithValue("@PDuzgunSecim", correctOption);
            cmd.Parameters.AddWithValue("@PSecimA", optionA);
            cmd.Parameters.AddWithValue("@PSecimB", optionB);
            cmd.Parameters.AddWithValue("@PSecimC", optionC);
            cmd.Parameters.AddWithValue("@PSecimD", optionD);
            cmd.Parameters.AddWithValue("@QuizId", quizID);
            //@PDuzgunSecim, @PSecimA, @PSecimB, @PSecimC, @PSecimD, @QuizId
            var setirSayi = cmd.ExecuteNonQuery();

            if (setirSayi > 0)
                ConsoleExtensions.PrintMessage("Sual uğurla yaradıldı ☑️", Enums.MessageType.Success);
            else
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);


            /*
            QuestionID
            QuestionText
            CorrectOption
            OptionA
            OptionB
            OptionC
            OptionD
            QuizID
            */
        }

        public static void UpdateQuestions(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("QuestionID       ||       QuestionText        ||       CorrectOption         ||      OptionA      ||       OptionB      ||      OptionC      ||       OptionD      ||      QuizID      ||");

            QuizAndQuestionCrud.SelectQuestions(conn).ForEach(q =>
            {
                Console.WriteLine(q);
            });

            Console.WriteLine("\nAşağıda məlumatlarını dəyişmək istədiyiniz sualın ID sini daxil edin.");
            int questionId = InputExtensions.GetInt();

            Console.WriteLine("Sualın mətnini daxil edin:");
            string updatedQuestionText = InputExtensions.GetNonNullString();
            Console.WriteLine("Sualın düzgün cavabını daxil edin: (A,B,C,D)");
            string updatedCorrectOption = InputExtensions.GetNonNullString();
            Console.WriteLine("A) variantının mətnini daxil edin:");
            string updatedOptionA = InputExtensions.GetNonNullString();
            Console.WriteLine("B) variantının mətnini daxil edin:");
            string updatedOptionB = InputExtensions.GetNonNullString();
            Console.WriteLine("C) variantının mətnini daxil edin:");
            string updatedOptionC = InputExtensions.GetNonNullString();
            Console.WriteLine("D) variantının mətnini daxil edin:");
            string updatedOptionD = InputExtensions.GetNonNullString();
            Console.WriteLine("QuizID ni daxil edin(int olaraq):");
            int updatedQuizID = InputExtensions.GetInt();

            var sqlUpdate = "UPDATE  Questions SET QuestionText = @Ptext, CorrectOption = @Pcorrectoption, OptionA = @PoptionA, OptionB = @PoptionB, OptionC = @PoptionC, OptionD = @PoptionD, QuizID = @PquizId WHERE QuestionID = @PquestionId";

            var cmd = conn.CreateCommand();
            cmd.CommandText = sqlUpdate;
            cmd.Parameters.AddWithValue("@PquestionId", questionId);
            cmd.Parameters.AddWithValue("@Ptext", updatedQuestionText);
            cmd.Parameters.AddWithValue("@Pcorrectoption", updatedCorrectOption);
            cmd.Parameters.AddWithValue("@PoptionA", updatedOptionA);
            cmd.Parameters.AddWithValue("@PoptionB", updatedOptionB);
            cmd.Parameters.AddWithValue("@PoptionC", updatedOptionC);
            cmd.Parameters.AddWithValue("@PoptionD", updatedOptionD);
            cmd.Parameters.AddWithValue("@PquizId", updatedQuizID);

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

        public static void RemoveQuestions(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("QuestionID       ||       QuestionText        ||       CorrectOption         ||      OptionA      ||       OptionB      ||      OptionC      ||       OptionD      ||      QuizID      ||");

            QuizAndQuestionCrud.SelectQuestions(conn).ForEach(q =>
            {
                Console.WriteLine(q);
            });

            Console.WriteLine("\nAşağıda silmək istədiyiniz sualın ID sini daxil edin.");
            int removequestionId = InputExtensions.GetInt();

            var sqlRemove = "DELETE FROM Questions WHERE QuestionID = @PquestionId";

            var cmd = conn.CreateCommand();

            cmd.CommandText = sqlRemove;
            cmd.Parameters.AddWithValue("@PquestionId", removequestionId);
            var setirSayi = cmd.ExecuteNonQuery();

            if (setirSayi > 0)
            {
                ConsoleExtensions.PrintMessage("Sual uğurla silindi ☑️", Enums.MessageType.Success);
            }
            else
            {
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);
            }
        }

        public static void AddUser(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("\n-----------------------------------");
            ConsoleExtensions.PrintMessage("Xaiş edirik yeni istifadəçi hesabını yaratmaq üçün aşağıda sırayla məlumatları daxil edin: ", Enums.MessageType.Info);

            Console.WriteLine("\nAdını daxil edin:");
            string userAdi = InputExtensions.GetNonNullString();
            Console.WriteLine("Soyadını daxil edin: ");
            string userSoyadi = InputExtensions.GetNonNullString();
            Console.WriteLine("Email adresini daxil edin:");
            string userEmail = InputExtensions.GetNonNullString();
            Console.WriteLine("Şifrəni daxil edin:");
            string userSifresi = InputExtensions.GetNonNullString();
            Console.WriteLine("Rol olaraq istifadəçi kimi sistemə daxil etmək üçün 1 daxil edin:");
            int userRole = InputExtensions.GetInt();
            Console.WriteLine("\n-----------------------------------");

            var sqlInsertcode = "INSERT INTO Users(FirstName, LastName, UserEmail, UserPassword, Roles) values(@PAd, @PSoyad, @PEmail, @PSifre, @PRol)";

            var cmd = conn.CreateCommand();
            cmd.CommandText = sqlInsertcode;
            cmd.Parameters.AddWithValue("@PAd", userAdi);
            cmd.Parameters.AddWithValue("@PSoyad", userSoyadi);
            cmd.Parameters.AddWithValue("@PEmail", userEmail);
            cmd.Parameters.AddWithValue("@PSifre", userSifresi);
            cmd.Parameters.AddWithValue("@PRol", userRole);

            var setirSayi = cmd.ExecuteNonQuery();

            if (setirSayi > 0)
            {
                ConsoleExtensions.PrintMessage("İstifadəçi hesabını uğurla yaradıldı 🤩", Enums.MessageType.Success);
            }
            else
            {
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);
            }
        }

        public static void UpdateUser(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("UserID       ||       FirstName        ||       LastName         ||      UserEmail      ||       UserPassword      ||      Roles      ||");

            GetAllUsers.GetUsers(conn).ForEach(q =>
            {
                Console.WriteLine(q);
            });


            Console.WriteLine("\n-----------------------------------");
            ConsoleExtensions.PrintMessage("Aşağıda məlumatlarını dəyişmək istədiyiniz istifadəçinin ID sini daxil edin.", Enums.MessageType.Info);
            int userId = InputExtensions.GetInt();

            Console.WriteLine("\nAdını daxil edin:");
            string updateduserFName = InputExtensions.GetNonNullString();
            Console.WriteLine("Soyadını daxil edin: ");
            string updatedLName = InputExtensions.GetNonNullString();
            Console.WriteLine("Email adresini daxil edin:");
            string updatedEmail = InputExtensions.GetNonNullString();
            Console.WriteLine("Şifrəni daxil edin:");
            string updatedPassword = InputExtensions.GetNonNullString();
            Console.WriteLine("Rol olaraq istifadəçi kimi sistemə daxil etmək üçün 1 daxil edin:");
            int updatedRole = InputExtensions.GetInt();
            Console.WriteLine("\n-----------------------------------");

            var sqlUpdate = "UPDATE  Users SET FirstName = @PFName, LastName = @PLName, UserEmail = @PEmail, UserPassword = @PPassword, Roles = @PRole WHERE UserID = @PuserId";

            var cmd = conn.CreateCommand();
            cmd.CommandText = sqlUpdate;
            cmd.Parameters.AddWithValue("@PuserId", userId);
            cmd.Parameters.AddWithValue("@PFName", updateduserFName);
            cmd.Parameters.AddWithValue("@PLName", updatedLName);
            cmd.Parameters.AddWithValue("@PEmail", updatedEmail);
            cmd.Parameters.AddWithValue("@PPassword", updatedPassword);
            cmd.Parameters.AddWithValue("@PRole", updatedRole);
            
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

        //TODO: Yaddan Cixartma!
        public static void RemoveUser(SqlConnection conn)
        {

        }


        public static List<Users> GetUsersStatistics(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("ScoreID       ||       QuizID        ||       UserID         ||      CorrectAnswers      ||       IncorrectAnswers      ||      TotalScore      ||");

            GetAllUsers.GetUsers(conn).ForEach(q =>
            {
                Console.WriteLine(q);
            });

            /*
            ScoreID
            QuizID
            UserID
            CorrectAnswers
            IncorrectAnswers
            TotalScore
            */
            var select = "SELECT * FROM Score";

            var cmd = conn.CreateCommand();
            cmd.CommandText = select;
            var reader = cmd.ExecuteReader();


            List<Users> userlist = new List<Users>();


            while (reader.Read())
            {
                var user = new Users();

                user.UserId = Convert.ToInt32(reader["UserID"]);
                user.FirstName = Convert.ToString(reader["FirstName"]);
                user.LastName = Convert.ToString(reader["LastName"]);
                user.UserEmail = Convert.ToString(reader["UserEmail"]);
                user.UserPassword = Convert.ToString(reader["UserPassword"]);
                user.Role = (UserRole)Convert.ToInt32(reader["Roles"]);

                userlist.Add(user);
            }
            reader.Close();

            return userlist;

            /*
            UserID
            FirstName
            LastName
            UserEmail
            UserPassword
            Roles
            */
        }
    }
}

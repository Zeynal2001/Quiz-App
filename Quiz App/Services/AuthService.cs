using Quiz_App.CustomExceptions;
using Quiz_App.Extensions;
using Quiz_App.Models;
using System.Data;
using System.Data.SqlClient;

namespace Quiz_App.Services
{
    public class AuthService
    {
        public static User Login(SqlConnection conn, UserRole loginType)
        {
            Console.WriteLine("\n-----------------------------------");
            ConsoleExtensions.PrintMessage("Xaiş edirik proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ", Enums.MessageType.Info);
            
            Console.WriteLine("\nEmaili daxil edn");
            string usersEmail = InputExtensions.GetNonNullString();

            Console.WriteLine("Şifrəni daxil edin");
            string usersSifre = InputExtensions.GetNonNullString();
            Console.WriteLine("\n-----------------------------------");

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Parametrler istifade edirik
            string sqlQuery = "SELECT * FROM Users WHERE UserEmail = @PEmail and UserPassword = @PSifre and Roles = @PRole";

            var adapter = new SqlDataAdapter(sqlQuery, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@PEmail", usersEmail);
            adapter.SelectCommand.Parameters.AddWithValue("@PSifre", usersSifre);
            adapter.SelectCommand.Parameters.AddWithValue("@PRole", (int)loginType);

            var table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                ConsoleExtensions.PrintMessage("Giriş uğurlu oldu ☑️.", Enums.MessageType.Success);
            }
            else
            {
                throw new AuthException("Email vəya şifrə yanlışdır 😕.");
            }

            User user = new User();

            foreach (DataRow row in table.Rows)
            {
                user.UserId = Convert.ToInt32(row[0]);
                user.FirstName = row[1].ToString();
                user.LastName = row[2].ToString();
                user.UserEmail = row[3].ToString();
                user.UserPassword = row[4].ToString();
                user.Role = (UserRole)Convert.ToInt32(row[5]);
            }

            return user;
        }

        public static void Register(SqlConnection conn, UserRole loginType)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            Console.WriteLine("\n-----------------------------------");
            ConsoleExtensions.PrintMessage("Xaiş edirik yeni hesab yaratmaq üçün aşağıda sırayla məlumatlarınızı daxil edin: ", Enums.MessageType.Info);
            
            Console.WriteLine("\nAdınızı daxil edin:");
            string adminAdi = InputExtensions.GetNonNullString();
            Console.WriteLine("Soyadınızı daxil edin: ");
            string adminSoyadi = InputExtensions.GetNonNullString();
            Console.WriteLine("Email adresinizi daxil edin:");
            string adminEmail = InputExtensions.GetNonNullString();
            Console.WriteLine("Şifrənizi daxil edin:");
            string adminSifresi = InputExtensions.GetNonNullString();
            Console.WriteLine("Admin rolu ilə register olmaq üçün 0 daxil edin:");
            int adminRole = InputExtensions.GetInt();
            Console.WriteLine("\n-----------------------------------");

            var sqlInsertcode = "INSERT INTO Users(FirstName, LastName, UserEmail, UserPassword, Roles) values(@PAd, @PSoyad, @PEmail, @PSifre, @PRol)";

            var cmd = conn.CreateCommand();
            cmd.CommandText = sqlInsertcode;
            cmd.Parameters.AddWithValue("@PAd", adminAdi);
            cmd.Parameters.AddWithValue("@PSoyad", adminSoyadi);
            cmd.Parameters.AddWithValue("@PEmail", adminEmail);
            cmd.Parameters.AddWithValue("@PSifre", adminSifresi);
            cmd.Parameters.AddWithValue("@PRol", adminRole);

            var setirSayi = cmd.ExecuteNonQuery();

            if (setirSayi > 0)
            {
                ConsoleExtensions.PrintMessage("Hesabınız uğurla yaradıldı 🤩", Enums.MessageType.Success);
            }
            else
            {
                ConsoleExtensions.PrintMessage("Xəta baş verdi 😕", Enums.MessageType.Error);
            }
        }
    }
}

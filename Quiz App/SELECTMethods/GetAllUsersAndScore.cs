using Quiz_App.Models;
using System.Data.SqlClient;
using System.Data;

namespace Quiz_App.SELECTMethods
{
    public class GetAllUsersAndScore
    {
        public static List<User> GetUsers(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var select = "SELECT * FROM Users";

            var cmd = conn.CreateCommand();
            cmd.CommandText = select;
            var reader = cmd.ExecuteReader();


            List<User> userlist = new List<User>();


            while (reader.Read())
            {
                var user = new User();

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

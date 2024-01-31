using Quiz_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.SELECTMethods
{
    public class GetAllUsers
    {
        public static List<Users> GetUsers(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var select = "SELECT * FROM Users";

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

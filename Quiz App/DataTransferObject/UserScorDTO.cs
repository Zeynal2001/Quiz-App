using System.Data;
using System.Data.SqlClient;

namespace Quiz_App.DataTransferObject
{
    public class UserScorDTO
    {
        public int ScoreId { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public string FullName { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public int TotalScore { get; set; }


        public static List<UserScorDTO> GetScore(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var cmd = conn.CreateCommand();

            var selectscore = "SELECT \r\n\t            s.ScoreID,\r\n\t            s.QuizID,\r\n\t            u.UserID,\r\n\t            CONCAT(u.FirstName, ' ', u.LastName) AS [Istifadeci Adi],\r\n\t            s.CorrectAnswers,\r\n\t            s.IncorrectAnswers,\r\n\t            s.TotalScore\r\n            FROM Score AS [s]\r\n            JOIN Users u ON s.UserID = u.UserID";
            cmd.CommandText = selectscore;

            var reader = cmd.ExecuteReader();

            List<UserScorDTO> userscorlist = new List<UserScorDTO>();


            while (reader.Read())
            {
                var userscore = new UserScorDTO();

                userscore.ScoreId = Convert.ToInt32(reader["ScoreID"]);
                userscore.QuizId = Convert.ToInt32(reader["QuizID"]);
                userscore.UserId = Convert.ToInt32(reader["UserID"]);
                userscore.FullName = reader["Istideci Adi"].ToString();
                userscore.CorrectAnswers = Convert.ToInt32(reader["CorrectAnswers"]);
                userscore.IncorrectAnswers = Convert.ToInt32(reader["IncorrectAnswers"]);
                userscore.TotalScore = Convert.ToInt32(reader["TotalScore"]);

                userscorlist.Add(userscore);
            }
            reader.Close();

            return userscorlist;
        }


        public static List<UserScorDTO> LookingAtYourOwnScore(SqlConnection conn, int userId = 0)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var cmd = conn.CreateCommand();

            if (userId > 0)
            {
              var  selectUserScore = "SELECT \r\n\t            s.ScoreID,\r\n\t            s.QuizID,\r\n\t            u.UserID,\r\n\t            CONCAT(u.FirstName, ' ', u.LastName) AS [Istifadeci Adi],\r\n\t            s.CorrectAnswers,\r\n\t            s.IncorrectAnswers,\r\n\t            s.TotalScore\r\n            FROM Score AS [s]\r\n            JOIN Users u ON s.UserID = u.UserID where s.UserID = @PUId";
                cmd.CommandText = selectUserScore;
                cmd.Parameters.AddWithValue("@PUId", userId);
            }
            else
            {
                var selectUserScore = "SELECT \r\n\t            s.ScoreID,\r\n\t            s.QuizID,\r\n\t            u.UserID,\r\n\t            CONCAT(u.FirstName, ' ', u.LastName) AS [Istifadeci Adi],\r\n\t            s.CorrectAnswers,\r\n\t            s.IncorrectAnswers,\r\n\t            s.TotalScore\r\n            FROM Score AS [s]\r\n            JOIN Users u ON s.UserID = u.UserID";
                cmd.CommandText = selectUserScore;  
            }
            /*
            SELECT 
	            s.ScoreID,
	            s.QuizID,
	            u.UserID,
	            CONCAT(u.FirstName, ' ', u.LastName) AS [Istifadeci Adi],
	            s.CorrectAnswers,
	            s.IncorrectAnswers,
	            s.TotalScore
            FROM Score AS [s]
            JOIN Users u ON s.UserID = u.UserID
            */

            var reader = cmd.ExecuteReader();


            List<UserScorDTO> userscorlist = new List<UserScorDTO>();


            while (reader.Read())
            {
                var userscore = new UserScorDTO();

                userscore.ScoreId = Convert.ToInt32(reader["ScoreID"]);
                userscore.QuizId = Convert.ToInt32(reader["QuizID"]);
                userscore.UserId = Convert.ToInt32(reader["UserID"]);
                userscore.FullName = reader["Istideci Adi"].ToString();
                userscore.CorrectAnswers = Convert.ToInt32(reader["CorrectAnswers"]);
                userscore.IncorrectAnswers = Convert.ToInt32(reader["IncorrectAnswers"]);
                userscore.TotalScore = Convert.ToInt32(reader["TotalScore"]);

                userscorlist.Add(userscore);
            }
            reader.Close();

            return userscorlist;
        }
    }
}

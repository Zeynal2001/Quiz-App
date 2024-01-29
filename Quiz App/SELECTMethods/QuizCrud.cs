using Quiz_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.SELECTMethods
{
    public class QuizCrud
    {
        public static List<Quizzes> SelectQuizzes(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var select = "SELECT * FROM Quizzes";

            var cmd = conn.CreateCommand();
            cmd.CommandText = select;
            var reader = cmd.ExecuteReader();
               
            
            List<Quizzes> quizlist = new List<Quizzes>();


            while (reader.Read())
            {
                var quiz = new Quizzes();

                quiz.QuizId = Convert.ToInt32(reader["QuizID"]);
                quiz.QuizName = Convert.ToString(reader["QuizName"]);
                quiz.Description = Convert.ToString(reader["DescriptionQ"]);
                DateTime.TryParse(reader["StartTime"].ToString(), out DateTime startDate);
                quiz.StartTime  = startDate;
                DateTime.TryParse(reader["EndTime"].ToString(), out DateTime endDate);
                quiz.EndTime = endDate;
                quiz.CategoryId = Convert.ToInt32(reader["CategoryID"]);
                quiz.QuizTitle = Convert.ToString(reader["QuizTitle"]);

                quizlist.Add(quiz);
            }
            reader.Close();

            return quizlist;
        }
    }
}

﻿using Quiz_App.Models;
using System.Data;
using System.Data.SqlClient;

namespace Quiz_App.SELECTMethods
{
    public class QuizQuestionAndAnswerCrud
    {
        public static List<Quiz> GetQuizzes(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var select = "SELECT * FROM Quizzes";

            var cmd = conn.CreateCommand();
            cmd.CommandText = select;
            var reader = cmd.ExecuteReader();
               
            
            List<Quiz> quizlist = new List<Quiz>();


            while (reader.Read())
            {
                var quiz = new Quiz();

                quiz.QuizId = Convert.ToInt32(reader["QuizID"]);
                quiz.QuizName = Convert.ToString(reader["QuizName"]);
                quiz.Description = Convert.ToString(reader["DescriptionQ"]);
                DateTime.TryParse(reader["StartTime"].ToString(), out DateTime startDate);
                quiz.StartTime  = startDate;
                //DateTime.TryParse(reader["EndTime"].ToString(), out DateTime endDate);
                //quiz.EndTime = endDate;
                quiz.EndTime = Convert.ToInt32(reader["EndTime"]);
                quiz.CategoryId = Convert.ToInt32(reader["CategoryID"]);
                quiz.QuizTitle = Convert.ToString(reader["QuizTitle"]);

                quizlist.Add(quiz);
            }
            reader.Close();

            return quizlist;
        }


        public static List<Quiz> GetQuizzes2(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var select = "SELECT QuizID, QuizName, CategoryID, QuizTitle  FROM Quizzes";
            //var str = "QuizID       ||       QuizName        ||       CategoryID      ||      QuizTitle      ||";
            var cmd = conn.CreateCommand();
            cmd.CommandText = select;
            var reader = cmd.ExecuteReader();


            List<Quiz> quizlist = new List<Quiz>();


            while (reader.Read())
            {
                var quiz = new Quiz();

                quiz.QuizId = Convert.ToInt32(reader["QuizID"]);
                quiz.QuizName = Convert.ToString(reader["QuizName"]);
                quiz.CategoryId = Convert.ToInt32(reader["CategoryID"]);
                quiz.QuizTitle = Convert.ToString(reader["QuizTitle"]);

                quizlist.Add(quiz);
            }
            reader.Close();

            return quizlist;
        }

        public static List<Question> GetQuestions(SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var select = "SELECT * FROM Questions";

            var cmd = conn.CreateCommand();
            cmd.CommandText = select;
            var reader = cmd.ExecuteReader();


            List<Question> questionlist = new List<Question>();


            while (reader.Read())
            {
                var question = new Question();

                question.QuestionId = Convert.ToInt32(reader["QuestionID"]);
                question.QuestionText = Convert.ToString(reader["QuestionText"]);
                question.CorrectOption = Convert.ToString(reader["CorrectOption"]);
                question.OptionA = Convert.ToString(reader["OptionA"]);
                question.OptionB = Convert.ToString(reader["OptionB"]);
                question.OptionC = Convert.ToString(reader["OptionC"]);
                question.OptionD = Convert.ToString(reader["OptionD"]);
                question.QuizId = Convert.ToInt32(reader["QuizID"]);

                questionlist.Add(question);
            }
            reader.Close();

            return questionlist;
        }

        public static List<Question> GetQuestionsByQuizId(SqlConnection conn, int quizId)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var select = "SELECT * FROM Questions WHERE QuizID = @PquizId";

            var cmd = conn.CreateCommand();
            cmd.CommandText = select;
            cmd.Parameters.AddWithValue("@PquizId", quizId);
            var reader = cmd.ExecuteReader();


            List<Question> questionlist = new List<Question>();


            while (reader.Read())
            {
                var question = new Question();

                question.QuestionId = Convert.ToInt32(reader["QuestionID"]);
                question.QuestionText = Convert.ToString(reader["QuestionText"]);
                question.CorrectOption = Convert.ToString(reader["CorrectOption"]);
                question.OptionA = Convert.ToString(reader["OptionA"]);
                question.OptionB = Convert.ToString(reader["OptionB"]);
                question.OptionC = Convert.ToString(reader["OptionC"]);
                question.OptionD = Convert.ToString(reader["OptionD"]);
                question.QuizId = Convert.ToInt32(reader["QuizID"]);

                questionlist.Add(question);
            }
            reader.Close();

            return questionlist;
        }
    }
}

using Quiz_App.Services;
using System.Data.SqlClient;
Console.OutputEncoding = System.Text.Encoding.UTF8;


string connStr = "Server=.;Database=QuizApp; Integrated Security=true";

var conn = new SqlConnection(connStr);
conn.Open();

if (conn.State == System.Data.ConnectionState.Open)
   Console.WriteLine("Ugurla qosuldu");






conn.Close();
if (conn.State == System.Data.ConnectionState.Closed)
    Console.WriteLine("Connection uğursuz oldu");

Menu.MainMenu();
Menu.AdminMenu();
Menu.CustomerMenu();
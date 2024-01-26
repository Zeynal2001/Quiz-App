using Quiz_App.CustomExceptions;
using Quiz_App.Enums;
using Quiz_App.Extensions;
using Quiz_App.Models;
using Quiz_App.Operating_Methods;
using Quiz_App.Services;
using System.Data.SqlClient;
Console.OutputEncoding = System.Text.Encoding.UTF8;


string connStr = "Server=.;Database=QuizApp; Integrated Security=true";

var conn = new SqlConnection(connStr);
conn.Open();

if (conn.State == System.Data.ConnectionState.Open)
   Console.WriteLine("Ugurla qosuldu");




MenuService.MainMenu();

var girisTipi = UserRole.None;

int secim1 = InputExtensions.GetInt();
//Əsas giriş
switch (secim1)
{
    //Admin kimi giriş etmək.
    case 1:

        bool duzdurmu = true;

        while (duzdurmu)
        {
            MenuService.AdminLoginOrRegister();
            try
            {
                int secim = InputExtensions.GetInt();

                switch (secim)
                {
                    //Login olmaq
                    case 1:
                        AuthService.Login(conn, UserRole.Admin);
                        duzdurmu = false;
                        girisTipi = UserRole.Admin;
                        break;
                    //Register olmaq
                    case 2:
                        AuthService.Register(conn, UserRole.Admin);
                        duzdurmu = false;
                        break;
                    //Geri qayitmaq
                    case 3:

                        break;
                    default:
                        //Yanlış seçim
                        ConsoleExtensions.PrintMessage("Yanlış seçim etmisiniz 😕.", MessageType.Error);
                        break;
                }
            }
            catch (AuthException ex)
            {
                // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                ConsoleExtensions.PrintMessage($"Xəta baş verdi: {ex.Message}", MessageType.Error);
            }
            finally
            {
                // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        break;
    //User kimi giriş etmək.
    case 2:

        bool duzdurmu2 = true;

        while (duzdurmu2)
        {
            MenuService.UserLoginOrRegister();

            try
            {
                int secim = InputExtensions.GetInt();

                switch (secim)
                {
                    //Login olmaq
                    case 1:
                        AuthService.Login(conn, UserRole.User);
                        duzdurmu2 = false;
                        girisTipi = UserRole.User;
                        break;
                    //Register olmaq
                    case 2:
                        AuthService.Register(conn, UserRole.User);
                        duzdurmu2 = false;
                        break;
                    //Geri qayitmaq
                    case 3:

                        break;
                    default:
                        //Yanlış seçim
                        ConsoleExtensions.PrintMessage("Yanlış seçim etmisiniz 😕.", MessageType.Error);
                        break;
                }

            }
            catch (AuthException ex)
            {
                // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                ConsoleExtensions.PrintMessage($"Xəta baş verdi: {ex.Message}", MessageType.Error);
            }
            finally
            {
                // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        break;
    //Proqramdan çıxış etmək.
    case 3:
        Console.WriteLine("Proqram bağlandı.");
        return;
    default:
        //Yanlış seçim
        ConsoleExtensions.PrintMessage("Yanlış seçim etmisiniz 😕.", MessageType.Error);
        break;
}

switch (girisTipi)
{
    case UserRole.None:
        break;
    case UserRole.User:

        bool duzdurmu1 = true;

        while (duzdurmu1)
        {
            MenuService.UserMenu();
            try
            {
                int secim = InputExtensions.GetInt();

                switch (secim)
                {
                    //Quizə başlamaq
                    case 1:

                        break;
                    //İştirak etdiyi quizlərə və nəticələrinə baxmaq
                    case 2:

                        break;
                    //Proqramı dayandırmaq
                    case 3:

                        break;
                    default:
                        //Yanlış seçim
                        ConsoleExtensions.PrintMessage("Yanlış seçim etmisiniz 😕.", MessageType.Error);
                        break;
                }
            }
            catch (AuthException ex)
            {
                // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                ConsoleExtensions.PrintMessage($"Xəta baş verdi: {ex.Message}", MessageType.Error);
            }
            finally
            {
                // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        break;
    case UserRole.Admin:

        bool duzdurmu2 = true;

        while (duzdurmu2)
        {
            MenuService.AdminMenu();
            try
            {
                int secim = InputExtensions.GetInt();

                switch (secim)
                {
                    //Quizləri yaratmaq
                    case 1:
                        ForAdmin.AddQuizzes(conn);
                        duzdurmu2 = false;
                        break;
                    //Quizləri yeniləmək
                    case 2:

                        break;
                    //Quizləri silmək
                    case 3:

                        break;
                    //Sualları yaratmaq
                    case 4:

                        break;
                    //Sualları yeniləmək
                    case 5:

                        break;
                    //Sualları silmək
                    case 6:

                        break;
                    //İstifadəçi hesabını yaratmaq
                    case 7:

                        break;
                    //İstifadəçi hesabını yeniləmək
                    case 8:

                        break;
                    //İstifadəçi hesabını silmək
                    case 9:

                        break;
                    //İstifadəçilərin istatistik məlumatlarına baxmaq
                    case 10:

                        break;
                    //Proqramı dayandır
                    case 11:

                        break;
                    //Programı sıfırla
                    case 12:

                        break;
                    default:
                        //Yanlış seçim
                        ConsoleExtensions.PrintMessage("Yanlış seçim etmisiniz 😕.", MessageType.Error);
                        break;
                }
            }
            catch (AuthException ex)
            {
                // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                ConsoleExtensions.PrintMessage($"Xəta baş verdi: {ex.Message}", MessageType.Error);
            }
            finally
            {
                // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        break;
    default:
        //Yanlış seçim
        ConsoleExtensions.PrintMessage("Yanlış seçim etmisiniz 😕.", MessageType.Error);
        break;
}




conn.Close();
if (conn.State == System.Data.ConnectionState.Closed)
    Console.WriteLine("Connection bağlandı və ya uğursuz oldu");
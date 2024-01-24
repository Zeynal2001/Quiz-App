namespace Quiz_App.Services
{
    public static class MenuService
    {
        public static void MainMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xoş gəlmisiniz 😊. Girişi seçin: (1/3)");
            Console.WriteLine("1. Admin kimi.");
            Console.WriteLine("2. İstifadəçi kimi.");
            Console.WriteLine("3. Proqramdan çıxış etmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void AdminLoginOrRegister()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Aşağıda seçiminizi edin: (1/3)");
            Console.WriteLine("1. Login olmaq");
            Console.WriteLine("2. Qeydiyyatdan keçmək (Register)");
            Console.WriteLine("3. Proqramı dayandır");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void AdminMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Aşağıda etmək istədiyiniz əməliyyatı seçin: (1/13)");
            Console.WriteLine("1. Quizləri yaratmaq.");
            Console.WriteLine("2. Quizləri yeniləmək");
            Console.WriteLine("3. Quizləri silmək");
            Console.WriteLine("4. Sualları yaratmaq");
            Console.WriteLine("5. Sualları yeniləmək");
            Console.WriteLine("6. Sualları silmək");
            Console.WriteLine("7. İstifadəçi hesabını yaratmaq");
            Console.WriteLine("8. İstifadəçi hesabını yeniləmək");
            Console.WriteLine("9. İstifadəçi hesabını silmək");
            Console.WriteLine("10. İstifadəçilərin istatistik məlumatlarına baxmaq");
            Console.WriteLine("11. Proqramı dayandır");
            Console.WriteLine("12. Programı sıfırla");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void UserLoginOrRegister()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Aşağıda seçiminizi edin: (1/3)");
            Console.WriteLine("1. Login olmaq");
            Console.WriteLine("2. Qeydiyyatdan keçmək (Register)");
            Console.WriteLine("3. Proqramı dayandır");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void UserMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Aşağıda etmək istədiyiniz əməliyyatı seçin: (1/3)");
            Console.WriteLine("1. Quizə başla");
            Console.WriteLine("2. İştirak etdiyin quizlərə və nəticələrinə baxmaq");
            Console.WriteLine("3. Proqramı dayandır");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        
    }
}

namespace Quiz_App.Services
{
    public static class Menu
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

        public static void AdminMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xoş gəlmisiniz 😊. Aşağıda etmək istədiyiniz əməliyyatı seçin: (1/13)");
            Console.WriteLine("1. Quizləri yaratmaq.");
            Console.WriteLine("2. Quizləri yeniləmək");
            Console.WriteLine("3. Quizləri silmək");
            Console.WriteLine("4. Sualları yaratmaq");
            Console.WriteLine("5. Sualları yeniləmək");
            Console.WriteLine("6. Sualları silmək");
            Console.WriteLine("8. İstifadəçi hesabını yaratmaq");
            Console.WriteLine("9. İstifadəçi hesabını yeniləmək");
            Console.WriteLine("10. İstifadəçi hesabını silmək");
            Console.WriteLine("11. İstifadəçilərin istatistik məlumatlarına baxmaq");
            Console.WriteLine("12. Programı dayandır");
            Console.WriteLine("13. Programı sıfırla");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void CustomerMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xoş gəlmisiniz 😊. Aşağıda etmək istədiyiniz əməliyyatı seçin: (1/3)");
            Console.WriteLine("1. Quizə başla");
            Console.WriteLine("2. İştirak etdiyin quizlərə və nəticələrinə baxmaq");
            Console.WriteLine("3. Programı dayandır");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }
    }
}

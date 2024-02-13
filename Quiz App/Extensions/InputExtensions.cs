using Quiz_App.Enums;

namespace Quiz_App.Extensions
{
    public class InputExtensions
    {
        static string _errorMesage = "Xəta: Daxil etdiyiniz dəyər doğru formatda deyil!";

        public static int GetInt()
        {
            int eded = 0;

            if (!int.TryParse(Console.ReadLine(), out eded))
            {
                ConsoleExtensions.PrintMessage(_errorMesage, MessageType.Error);
            }

            return eded;
        }

        public static double GetDouble(bool isMessage = true) 
        {
            double eded = 0;

            if (!double.TryParse(Console.ReadLine(), out eded))
            {
                ConsoleExtensions.PrintMessage(_errorMesage, MessageType.Error);
            }

            return eded;
        }

        public static string GetNonNullString()
        {
            string? input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                ConsoleExtensions.PrintMessage("Daxil etdiyiniz dəyər boşdur. Xaiş edirik duzgun dəyər daxil edin!", MessageType.Info);
                Thread.Sleep(1300);
                Console.Clear();
                input = Console.ReadLine();
            }

            return input;
        }
    }
}

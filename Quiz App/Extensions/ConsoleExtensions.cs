using Quiz_App.Enums;

namespace Quiz_App.Extensions
{
    public class ConsoleExtensions
    {
        public static void PrintMessage(string message, MessageType messageType = MessageType.None)
        {
            switch (messageType)
            {
                case MessageType.None:
                    break;
                case MessageType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageType.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

namespace Quiz_App.CustomExceptions
{
    public class AuthException : Exception
    {
        public AuthException()
        {

        }

        public AuthException(string? message) : base(message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public AuthException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

    }
}

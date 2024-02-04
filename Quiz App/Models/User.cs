namespace Quiz_App.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public UserRole Role { get; set; }


        public override string ToString()
        {
            return $"{UserId}  ||  {FirstName}  ||  {LastName}  ||  {UserEmail}  ||  {UserPassword}  ||  {Role}  ||";
        }
    }
    
    public enum UserRole
    {
        None,
        User,
        Admin
    }
}

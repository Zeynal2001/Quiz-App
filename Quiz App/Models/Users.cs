namespace Quiz_App.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public UserRole Role { get; set; }
    }
    
    public enum UserRole
    {
        None,
        User,
        Admin
    }
}

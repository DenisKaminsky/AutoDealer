namespace AutoDealer.Business.Models.Commands.User
{
    public class LogInInfo
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

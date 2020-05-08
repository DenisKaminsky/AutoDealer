namespace AutoDealer.Business.Models.Commands.User
{
    public class UserResetPasswordCommand
    {
        public int UserId { get; set; }
        public string NewPasswordHash { get; set; }
    }
}

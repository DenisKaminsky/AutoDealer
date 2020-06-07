namespace AutoDealer.Business.Models.Commands.User
{
    public class UserUpdatePasswordCommand
    {
        public int UserId { get; set; }
        public string OldPasswordHash { get; set; }
        public string NewPasswordHash { get; set; }
    }
}

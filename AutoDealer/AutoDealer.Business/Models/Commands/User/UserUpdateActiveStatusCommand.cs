namespace AutoDealer.Business.Models.Commands.User
{
    public class UserUpdateActiveStatusCommand
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}

namespace AutoDealer.Web.ViewModels.Request.User
{
    public class UserResetPasswordViewModel
    {
        public int UserId { get; set; }
        public string NewPasswordHash { get; set; }
    }
}

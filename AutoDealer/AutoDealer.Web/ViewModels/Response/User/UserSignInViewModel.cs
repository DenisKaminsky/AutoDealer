using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.User
{
    public class UserSignInViewModel : BaseViewModel
    {
        public UserRoleViewModel Role { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

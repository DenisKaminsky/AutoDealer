using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.User
{
    public class UserContactInfoViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}

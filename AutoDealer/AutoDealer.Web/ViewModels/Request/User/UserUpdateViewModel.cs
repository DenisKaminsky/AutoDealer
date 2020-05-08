using System;
using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Request.User
{
    public class UserUpdateViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }
    }
}

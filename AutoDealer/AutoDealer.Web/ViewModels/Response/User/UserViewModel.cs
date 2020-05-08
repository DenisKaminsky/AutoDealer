using System;
using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.User
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public UserRoleViewModel Role { get; set; }
    }
}

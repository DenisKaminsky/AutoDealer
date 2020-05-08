using System;

namespace AutoDealer.Web.ViewModels.Request.User
{
    public class UserCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }
        public int RoleId { get; set; }
    }
}

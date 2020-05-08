using System;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.User
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public UserRole Role { get; set; }
    }
}

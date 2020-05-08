using System;

namespace AutoDealer.Business.Models.Responses.User
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public bool IsMale { get; }
        public DateTime CreatedDate { get; }
        public DateTime Birthday { get; }
        public int Salary { get; }
        public bool IsActive { get; }
        public UserRoleModel Role { get; }

        public UserModel(int id, string firstName, string lastName, string email, string phone, bool isMale, DateTime createdDate, DateTime birthday, int salary, bool isActive, UserRoleModel role) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            IsMale = isMale;
            CreatedDate = createdDate;
            Birthday = birthday;
            Salary = salary;
            IsActive = isActive;
            Role = role;
        }
    }
}

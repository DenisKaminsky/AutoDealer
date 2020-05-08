using System;

namespace AutoDealer.Business.Models.Responses.User
{
    public class ClientModel : BaseModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PassportId { get; }
        public string Phone { get; }
        public bool IsMale { get; }
        public DateTime Birthday { get; }
        public string Address { get; }

        public ClientModel(int id, string firstName, string lastName, string email, string passportId, string phone, bool isMale, DateTime birthday, string address) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PassportId = passportId;
            Phone = phone;
            IsMale = isMale;
            Birthday = birthday;
            Address = address;
        }
    }
}

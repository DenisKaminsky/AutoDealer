using System;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.User
{
    public class Client : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassportId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsMale { get; set; }
        public DateTime Birthday { get; set; }
    }
}

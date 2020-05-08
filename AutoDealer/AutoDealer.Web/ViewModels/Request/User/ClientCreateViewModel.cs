using System;

namespace AutoDealer.Web.ViewModels.Request.User
{
    public class ClientCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassportId { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}

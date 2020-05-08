using System.Collections.Generic;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.User
{
    public class UserRole : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}

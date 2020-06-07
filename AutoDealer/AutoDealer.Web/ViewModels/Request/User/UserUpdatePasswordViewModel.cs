using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealer.Web.ViewModels.Request.User
{
    public class UserUpdatePasswordViewModel
    {
        public string OldPasswordHash { get; set; }
        public string NewPasswordHash { get; set; }
    }
}

using System;
using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.User
{
    public class UserUpdateCommand : IUpdateCommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }
    }
}

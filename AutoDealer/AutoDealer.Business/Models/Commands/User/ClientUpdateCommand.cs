using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.User
{
    public class ClientUpdateCommand : ClientCreateCommand, IUpdateCommand
    {
        public int Id { get; set; }
    }
}

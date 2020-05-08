using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.User;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.User
{
    public interface IClientCommandFunctionality : IBaseGenericCreateUpdateDeleteCommandFunctionality<ClientCreateCommand, ClientUpdateCommand>
    {
    }
}

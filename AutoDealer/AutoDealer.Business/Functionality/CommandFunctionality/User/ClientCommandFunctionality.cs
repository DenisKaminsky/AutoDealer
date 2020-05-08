using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.User;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.User;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.User
{
    public class ClientCommandFunctionality : BaseGenericCreateUpdateDeleteCommandFunctionality<ClientCreateCommand, ClientUpdateCommand, Client>, IClientCommandFunctionality
    {
        public ClientCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }
    }
}

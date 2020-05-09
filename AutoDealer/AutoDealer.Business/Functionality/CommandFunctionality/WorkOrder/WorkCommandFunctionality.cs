using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.WorkOrder;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.WorkOrder;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.WorkOrder
{
    public class WorkCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<WorkCreateCommand, Work>, IWorkCommandFunctionality
    {
        public WorkCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }
    }
}

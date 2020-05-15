using System.Threading.Tasks;
using AutoDealer.Business.Control;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Order;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Order;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Order
{
    public class DeliveryRequestCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<DeliveryRequestFromStockCreateCommand, DeliveryRequest>, IDeliveryRequestCommandFunctionality
    {
        public DeliveryRequestCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }
    }
}

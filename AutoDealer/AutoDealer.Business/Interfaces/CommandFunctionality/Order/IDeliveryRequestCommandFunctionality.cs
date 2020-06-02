using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Order;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Order
{
    public interface IDeliveryRequestCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<DeliveryRequestCreateCommand>
    {
    }
}

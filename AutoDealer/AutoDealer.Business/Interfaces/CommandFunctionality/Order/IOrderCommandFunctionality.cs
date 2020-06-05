using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Order;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Order
{
    public interface IOrderCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<OrderFromStockCreateCommand>
    {
        Task Promote(OrderPromoteCommand command);
        Task<int> AddWithDeliveryRequestAsync(OrderWithDeliveryRequestCreateCommand command);
    }
}

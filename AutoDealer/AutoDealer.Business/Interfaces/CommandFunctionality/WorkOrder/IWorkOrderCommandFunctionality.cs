using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.WorkOrder;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.WorkOrder
{
    public interface IWorkOrderCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<WorkOrderCreateCommand>
    {
        Task CompleteAsync(int orderId);
    }
}

using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.WorkOrder;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.WorkOrder
{
    public interface IWorkCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<WorkCreateCommand>
    {
    }
}

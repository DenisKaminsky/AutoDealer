using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.WorkOrder;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.WorkOrder
{
    public interface IWorkOrderQueryFunctionality : IGenericQueryFunctionality<WorkOrderModel>
    {
        Task<IEnumerable<WorkOrderModel>> GetByWorkerIdAsync(int workerId);
    }
}

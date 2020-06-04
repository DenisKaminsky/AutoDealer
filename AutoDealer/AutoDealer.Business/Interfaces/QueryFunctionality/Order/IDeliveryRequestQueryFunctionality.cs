using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.Order;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Order
{
    public interface IDeliveryRequestQueryFunctionality : IGenericQueryFunctionality<DeliveryRequestModel>
    {
        Task<IEnumerable<DeliveryRequestModel>> GetByManagerAsync(int managerId);
        Task<IEnumerable<DeliveryRequestModel>> GetBySupplierManagerAsync(int supplierManagerId);
        Task<IEnumerable<DeliveryRequestModel>> GetByStatusIdAsync(int statusId);
        Task<int?> GetAssignedSupplierManagerByDeliveryRequestId(int id);
    }
}

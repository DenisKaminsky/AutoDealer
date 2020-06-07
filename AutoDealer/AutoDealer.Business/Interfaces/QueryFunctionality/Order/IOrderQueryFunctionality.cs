using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Business.Models.Responses.Order;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Order
{
    public interface IOrderQueryFunctionality : IGenericQueryFunctionality<OrderModel>
    {
        Task<IEnumerable<OrderModel>> GetByManagerAsync(int managerId);

        Task<IEnumerable<OrderModel>> GetByClientAsync(int clientId);

        Task<IEnumerable<OrderModel>> GetByStatusIdAsync(int statusId);

        Task<int?> GetAssignedManagerByOrderId(int id);

        Task<IEnumerable<StatisticsDateCountModel>> GetStatisticsForLastDays(uint daysCount);
    }
}

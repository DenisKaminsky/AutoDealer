using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Order;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Order;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Order;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Order
{
    public class OrderStatusQueryFunctionality : BaseGenericQueryFunctionality<OrderStatusModel, OrderStatus>, IOrderStatusQueryFunctionality
    {
        public OrderStatusQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IOrderStatusFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository, filtersProvider)
        {
        }
    }
}

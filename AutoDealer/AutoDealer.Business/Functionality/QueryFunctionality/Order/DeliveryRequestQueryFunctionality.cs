using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Order;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Order;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Interfaces.RelationsProviders.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Order;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Order
{
    public class DeliveryRequestQueryFunctionality : BaseQueryFunctionality, IDeliveryRequestQueryFunctionality
    {
        private readonly IDeliveryRequestFiltersProvider _filtersProvider;
        private readonly IDeliveryRequestRelationsProvider _relationsProvider;

        public DeliveryRequestQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IDeliveryRequestFiltersProvider filtersProvider, IDeliveryRequestRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
            _relationsProvider = relationsProvider;
        }

        public async Task<IEnumerable<DeliveryRequestModel>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllQueryableAsync<DeliveryRequest>(_relationsProvider.JoinDeliveryRequestInfo);
            return Mapper.Map<IEnumerable<DeliveryRequestModel>>(items);
        }

        public async Task<DeliveryRequestModel> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationsProvider.JoinDeliveryRequestInfo);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<DeliveryRequestModel>(item);
        }

        public async Task<IEnumerable<DeliveryRequestModel>> GetByManagerAsync(int managerId)
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.ByManagerId(managerId), _relationsProvider.JoinDeliveryRequestInfo);
            return Mapper.Map<IEnumerable<DeliveryRequestModel>>(items);
        }

        public async Task<IEnumerable<DeliveryRequestModel>> GetBySupplierManagerAsync(int supplierManagerId)
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.BySupplierManagerId(supplierManagerId), _relationsProvider.JoinDeliveryRequestInfo);
            return Mapper.Map<IEnumerable<DeliveryRequestModel>>(items);
        }

        public async Task<IEnumerable<DeliveryRequestModel>> GetByStatusIdAsync(int statusId)
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.ByStatusId(statusId), _relationsProvider.JoinDeliveryRequestInfo);
            return Mapper.Map<IEnumerable<DeliveryRequestModel>>(items);
        }
    }
}

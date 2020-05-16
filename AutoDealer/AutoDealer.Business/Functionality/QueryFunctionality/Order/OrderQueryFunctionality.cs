﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Order;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Order;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Interfaces.RelationsProviders.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Order
{
    public class OrderQueryFunctionality : BaseQueryFunctionality, IOrderQueryFunctionality
    {
        private readonly IOrderFiltersProvider _filtersProvider;
        private readonly IOrderRelationsProvider _relationsProvider;

        public OrderQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IOrderFiltersProvider filtersProvider, IOrderRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
            _relationsProvider = relationsProvider;
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllQueryableAsync<Data.Models.Order.Order>(_relationsProvider.JoinOrderInfo);
            return Mapper.Map<IEnumerable<OrderModel>>(items);
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationsProvider.JoinOrderInfo);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<OrderModel>(item);
        }

        public async Task<IEnumerable<OrderModel>> GetByManagerAsync(int managerId)
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.ByManagerId(managerId), _relationsProvider.JoinOrderInfo);
            return Mapper.Map<IEnumerable<OrderModel>>(items);
        }

        public async Task<IEnumerable<OrderModel>> GetByClientAsync(int clientId)
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.ByClientId(clientId), _relationsProvider.JoinOrderInfo);
            return Mapper.Map<IEnumerable<OrderModel>>(items);
        }

        public async Task<IEnumerable<OrderModel>> GetByStatusIdAsync(int statusId)
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.ByStatusId(statusId), _relationsProvider.JoinOrderInfo);
            return Mapper.Map<IEnumerable<OrderModel>>(items);
        }
    }
}
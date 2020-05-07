using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Car
{
    public class CarStockQueryFunctionality : BaseQueryFunctionality, ICarStockQueryFunctionality
    {
        private readonly ICarStockRelationsProvider _relationsProvider;
        private readonly ICarStockFiltersProvider _filtersProvider;

        public CarStockQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, ICarStockRelationsProvider relationsProvider, ICarStockFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _relationsProvider = relationsProvider;
            _filtersProvider = filtersProvider;
        }

        public async Task<IEnumerable<CarStockModel>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllAsync<CarStock>(_relationsProvider.JoinAll);
            return Mapper.Map<IEnumerable<CarStockModel>>(items);
        }

        public async Task<IEnumerable<CarStockModel>> GetAllInStockAsync()
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.InStock(), _relationsProvider.JoinAll);
            return Mapper.Map<IEnumerable<CarStockModel>>(items);
        }

        public async Task<CarStockModel> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationsProvider.JoinAll);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<CarStockModel>(item);
        }

        public async Task<CarStockModel> GetInStockByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_filtersProvider.InStockById(id), _relationsProvider.JoinAll);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<CarStockModel>(item);
        }
    }
}

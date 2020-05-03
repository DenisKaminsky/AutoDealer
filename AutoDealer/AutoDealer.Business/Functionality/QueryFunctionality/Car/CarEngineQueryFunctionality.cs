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
    public class CarEngineQueryFunctionality : BaseQueryFunctionality, ICarEngineQueryFunctionality
    {
        private readonly ICarEngineFiltersProvider _filtersProvider;
        private readonly ICarEngineRelationsProvider _relationsProvider;

        public CarEngineQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, ICarEngineFiltersProvider filtersProvider, ICarEngineRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
            _relationsProvider = relationsProvider;
        }

        public async Task<IEnumerable<CarEngineModel>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllAsync<CarEngine>(_relationsProvider.JoinEngineType);
            return Mapper.Map<IEnumerable<CarEngineModel>>(items);
        }

        public async Task<CarEngineModel> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationsProvider.JoinEngineType);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<CarEngineModel>(item);
        }
    }
}

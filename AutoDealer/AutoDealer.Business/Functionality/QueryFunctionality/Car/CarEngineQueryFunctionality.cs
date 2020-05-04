using System.Collections.Generic;
using System.Linq;
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
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Car
{
    public class CarEngineQueryFunctionality : BaseQueryFunctionality, ICarEngineQueryFunctionality
    {
        private readonly ICarEngineFiltersProvider _engineFiltersProvider;
        private readonly ICarEngineRelationsProvider _engineRelationsProvider;
        private readonly IEngineSupportsGearboxFiltersProvider _engineGearboxFiltersProvider;
        private readonly IEngineSupportsGearboxRelationsProvider _engineGearboxRelationsProvider;

        public CarEngineQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, 
            ICarEngineFiltersProvider engineFiltersProvider, ICarEngineRelationsProvider engineRelationsProvider, 
            IEngineSupportsGearboxFiltersProvider engineGearboxFiltersProvider, IEngineSupportsGearboxRelationsProvider engineGearboxRelationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _engineFiltersProvider = engineFiltersProvider;
            _engineRelationsProvider = engineRelationsProvider;
            _engineGearboxFiltersProvider = engineGearboxFiltersProvider;
            _engineGearboxRelationsProvider = engineGearboxRelationsProvider;
        }

        public async Task<IEnumerable<CarEngineModel>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllAsync<CarEngine>(_engineRelationsProvider.JoinEngineType);
            return Mapper.Map<IEnumerable<CarEngineModel>>(items);
        }

        public async Task<IEnumerable<CarEngineWithGearboxModel>> GetAllEngineGearboxPairsAsync()
        {
            var items = await ReadRepository.GetAllAsync<EngineSupportsGearbox>(_engineGearboxRelationsProvider.JoinGearboxAndEngine);
            var result = items.GroupBy(x => new { x.ModelId, x.EngineId }).Select(x => x.First());
            return Mapper.Map<IEnumerable<CarEngineWithGearboxModel>>(result);
        }

        public async Task<IEnumerable<CarEngineWithGearboxModel>> GetEngineGearboxPairsByModelIdAsync(int id)
        {
            var items = await ReadRepository
                .GetAsync(_engineGearboxFiltersProvider.ByModelId(id), _engineGearboxRelationsProvider.JoinGearboxAndEngine);

            return Mapper.Map<IEnumerable<CarEngineWithGearboxModel>>(items);
        }

        public async Task<CarEngineModel> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_engineFiltersProvider.ById(id), _engineRelationsProvider.JoinEngineType);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<CarEngineModel>(item);
        }
    }
}

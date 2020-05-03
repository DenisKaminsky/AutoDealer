using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Car
{
    public class CarEngineTypeQueryFunctionality : BaseQueryFunctionality, ICarEngineTypeQueryFunctionality
    {
        private readonly ICarEngineTypeQueryFiltersProvider _filtersProvider;

        public CarEngineTypeQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, ICarEngineTypeQueryFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
        }

        public async Task<IEnumerable<CarEngineTypeModel>> GetAllAsync()
        {
            var engineTypes = await ReadRepository.GetAllAsync<CarEngineType>();
            return Mapper.Map<IEnumerable<CarEngineTypeModel>>(engineTypes);
        }

        public async Task<CarEngineTypeModel> GetByIdAsync(int id)
        {
            var engineType = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id));

            if (engineType == null)
                throw new NotFoundException("Car engine type was not found!");

            return Mapper.Map<CarEngineTypeModel>(engineType);
        }
    }
}

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

namespace AutoDealer.Business.Functionality.QueryFunctionality.Car
{
    public class CarModelQueryFunctionality : BaseGenericQueryFunctionality<CarModelModel, CarModel>, ICarModelQueryFunctionality
    {
        private readonly ICarModelFiltersProvider _filtersProvider;

        public CarModelQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericReadRepository readRepository, ICarModelFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository, filtersProvider)
        {
            _filtersProvider = filtersProvider;
        }
        
        public async Task<IEnumerable<CarModelModel>> GetByBrandIdAsync(int id)
        {
            var carModels = await ReadRepository.GetAsync(_filtersProvider.ByBrandId(id));

            return Mapper.Map<IEnumerable<CarModelModel>>(carModels);
        }
    }
}

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
    public class CarComplectationQueryFunctionality : BaseGenericQueryFunctionality<CarComplectationModel, CarComplectation>, ICarComplectationQueryFunctionality
    {
        private readonly ICarComplectationFiltersProvider _filtersProvider;

        public CarComplectationQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, ICarComplectationFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository, filtersProvider)
        {
            _filtersProvider = filtersProvider;
        }

        public async Task<IEnumerable<CarComplectationModel>> GetByModelIdAsync(int id)
        {
            var items = await ReadRepository.GetAsync(_filtersProvider.ByModelId(id));

            return Mapper.Map<IEnumerable<CarComplectationModel>>(items);
        }
    }
}

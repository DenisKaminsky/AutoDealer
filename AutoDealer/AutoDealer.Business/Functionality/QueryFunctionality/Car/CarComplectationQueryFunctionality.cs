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
        private readonly ICarComplectationFiltersProvider _complectationFiltersProvider;
        private readonly ICarComplectationOptionFiltersProvider _complectationOptionFiltersProvider;

        public CarComplectationQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, 
            ICarComplectationFiltersProvider complectationFiltersProvider, ICarComplectationOptionFiltersProvider complectationOptionFiltersProvider) 
            : base(unitOfWork, mapperFactory, readRepository, complectationFiltersProvider)
        {
            _complectationFiltersProvider = complectationFiltersProvider;
            _complectationOptionFiltersProvider = complectationOptionFiltersProvider;
        }

        public async Task<IEnumerable<CarComplectationModel>> GetByModelIdAsync(int id)
        {
            var items = await ReadRepository.GetAsync(_complectationFiltersProvider.ByModelId(id));

            return Mapper.Map<IEnumerable<CarComplectationModel>>(items);
        }

        public async Task<IEnumerable<CarComplectationOptionModel>> GetOptionsByComplectationIdAsync(int id)
        {
            var items = await ReadRepository.GetAsync(_complectationOptionFiltersProvider.ByComplectationId(id));

            return Mapper.Map<IEnumerable<CarComplectationOptionModel>>(items);
        }
    }
}

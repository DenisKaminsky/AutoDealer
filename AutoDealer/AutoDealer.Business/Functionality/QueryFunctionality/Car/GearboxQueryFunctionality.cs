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
    public class GearboxQueryFunctionality : BaseQueryFunctionality, IGearboxQueryFunctionality
    {
        private readonly IGearboxFiltersProvider _filtersProvider;

        public GearboxQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericReadRepository readRepository, IGearboxFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
        }

        public async Task<IEnumerable<GearboxModel>> GetAllAsync()
        {
            var gearboxes = await ReadRepository.GetAllAsync<Gearbox>();
            return Mapper.Map<IEnumerable<GearboxModel>>(gearboxes);
        }

        public async Task<GearboxModel> GetByIdAsync(int id)
        {
            var gearbox = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id));

            if (gearbox == null)
                throw new NotFoundException("Gearbox was not found!");

            return Mapper.Map<GearboxModel>(gearbox);
        }
    }
}

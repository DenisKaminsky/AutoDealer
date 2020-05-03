using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.RelationsProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Miscellaneous
{
    public class BrandQueryFunctionality: BaseQueryFunctionality, IBrandQueryFunctionality
    {
        private readonly IBrandFiltersProvider _filtersProvider;
        private readonly IBrandRelationsProvider _relationsProvider;

        public BrandQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, 
            IBrandFiltersProvider filtersProvider, IBrandRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
            _relationsProvider = relationsProvider;
        }

        public async Task<IEnumerable<BrandModel>> GetAllAsync()
        {
            var brands = await ReadRepository.GetAllAsync<Brand>(_relationsProvider.JoinCountry);
            return Mapper.Map<IEnumerable<BrandModel>>(brands);
        }

        public async Task<IEnumerable<BrandModel>> GetWithSupplierAsync()
        {
            var brands = await ReadRepository.GetAsync(_filtersProvider.WithSupplier(), _relationsProvider.JoinCountry);
            return Mapper.Map<IEnumerable<BrandModel>>(brands);
        }

        public async Task<IEnumerable<BrandModel>> GetByCountryIdAsync(int countryId)
        {
            var brands = await ReadRepository.GetAsync(_filtersProvider.ByCountryId(countryId), _relationsProvider.JoinCountry);
            return Mapper.Map<IEnumerable<BrandModel>>(brands);
        }

        public async Task<BrandModel> GetByIdAsync(int id)
        {
            var brand = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationsProvider.JoinCountry);

            if (brand == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<BrandModel>(brand);
        }
    }
}

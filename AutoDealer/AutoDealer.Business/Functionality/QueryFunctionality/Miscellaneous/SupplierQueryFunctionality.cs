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
    public class SupplierQueryFunctionality : BaseQueryFunctionality, ISupplierQueryFunctionality
    {
        private readonly ISupplierFiltersProvider _filtersProvider;
        private readonly ISupplierRelationsProvider _relationsProvider;

        public SupplierQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, 
            ISupplierFiltersProvider filtersProvider, ISupplierRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
            _relationsProvider = relationsProvider;
        }

        public async Task<IEnumerable<SupplierModel>> GetAllAsync()
        {
            var suppliers = await ReadRepository.GetAllAsync<Supplier>(_relationsProvider.JoinBrandAndCountry);
            return Mapper.Map<IEnumerable<SupplierModel>>(suppliers);
        }
        
        public async Task<SupplierModel> GetByIdAsync(int id)
        {
            var supplier = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationsProvider.JoinBrandAndCountry);

            if (supplier == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<SupplierModel>(supplier);
        }

        public async Task<SupplierModel> GetByBrandIdAsync(int id)
        {
            var supplier = await ReadRepository.GetSingleAsync(_filtersProvider.ByBrandId(id), _relationsProvider.JoinBrandAndCountry);

            if (supplier == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<SupplierModel>(supplier);
        }
    }
}

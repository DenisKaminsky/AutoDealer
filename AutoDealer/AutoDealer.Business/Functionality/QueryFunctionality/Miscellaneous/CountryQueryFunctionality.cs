using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Miscellaneous
{
    public class CountryQueryFunctionality : BaseQueryFunctionality, ICountryQueryFunctionality
    {
        private readonly ICountryFiltersProvider _countryFiltersProvider;

        public CountryQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericReadRepository readRepository, ICountryFiltersProvider countryFiltersProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _countryFiltersProvider = countryFiltersProvider;
        }

        public async Task<IEnumerable<CountryModel>> GetAllAsync()
        {
            var countries = await ReadRepository.GetAllAsync<Country>();
            return Mapper.Map<IEnumerable<CountryModel>>(countries);
        }

        public async Task<CountryModel> GetByIdAsync(int id)
        {
            var country = await ReadRepository.GetSingleAsync(_countryFiltersProvider.ById(id));
            
            if (country == null)
                throw new NotFoundException("Country was not found!");

            return Mapper.Map<CountryModel>(country);
        }
    }
}

using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Miscellaneous
{
    public class CountryQueryFunctionality : BaseGenericQueryFunctionality<CountryModel, Country>, ICountryQueryFunctionality
    {
        public CountryQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericReadRepository readRepository, ICountryFiltersProvider countryFiltersProvider) : base(unitOfWork, mapperFactory, readRepository, countryFiltersProvider)
        {
        }
    }
}

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
    public class GearboxQueryFunctionality : BaseGenericQueryFunctionality<GearboxModel, Gearbox>, IGearboxQueryFunctionality
    {
        public GearboxQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericReadRepository readRepository, IGearboxFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository, filtersProvider)
        {
        }
    }
}

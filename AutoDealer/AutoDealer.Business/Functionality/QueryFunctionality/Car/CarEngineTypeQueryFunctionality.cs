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
    public class CarEngineTypeQueryFunctionality : BaseGenericQueryFunctionality<CarEngineTypeModel, CarEngineType>, ICarEngineTypeQueryFunctionality
    {
        public CarEngineTypeQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericReadRepository readRepository, ICarEngineTypeFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository, filtersProvider)
        {
        }
    }
}

using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarEngineTypeQueryFiltersProvider : BaseFiltersProvider<CarEngineType>, ICarEngineTypeQueryFiltersProvider
    {
    }
}

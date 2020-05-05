using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.Car
{
    public class CarStockFiltersProvider : BaseFiltersProvider<CarStock>, ICarStockFiltersProvider
    {
    }
}

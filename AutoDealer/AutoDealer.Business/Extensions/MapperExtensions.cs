using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Miscellaneous;
using AutoMapper;

namespace AutoDealer.Business.Extensions
{
    public static class MapperExtensions
    {
        public static IMapper GetMapper()
        {
            return new MapperConfiguration(config =>
            {
                #region Commands
                config.CreateMap<CountryCreateCommand, Country>();
                config.CreateMap<CountryUpdateCommand, Country>();
                config.CreateMap<BrandCreateCommand, Brand>();
                config.CreateMap<BrandUpdateCommand, Brand>();
                config.CreateMap<SupplierCreateCommand, Supplier>();
                config.CreateMap<SupplierUpdateCommand, Supplier>();

                config.CreateMap<CarModelCreateCommand, CarModel>();
                config.CreateMap<CarModelUpdateCommand, CarModel>();
                #endregion

                #region Responses
                config.CreateMap<Country, CountryModel>();
                config.CreateMap<Brand, BrandModel>();
                config.CreateMap<Supplier, SupplierModel>();

                config.CreateMap<CarModel, CarModelModel>();
                #endregion
            }).CreateMapper();
        }
    }
}

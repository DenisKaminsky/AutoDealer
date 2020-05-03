using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Car.Relations;
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
                config.CreateMap<ColorCodeCreateCommand, ColorCode>();

                config.CreateMap<CarModelCreateCommand, CarModel>();
                config.CreateMap<CarModelUpdateCommand, CarModel>();
                config.CreateMap<CarBodyTypeCreateCommand, CarBodyType>();
                config.CreateMap<CarBodyTypeAssignCommand, ModelSupportsBodyType>();
                config.CreateMap<CarColorAssignmentCommand, ModelSupportsColor>();
                config.CreateMap<CarEngineTypeCreateCommand, CarEngineType>();
                config.CreateMap<GearboxCreateCommand, Gearbox>();
                config.CreateMap<CarEngineCreateCommand, CarEngine>();
                config.CreateMap<CarEngineUpdateCommand, CarEngine>();
                #endregion

                #region Responses
                config.CreateMap<Country, CountryModel>();
                config.CreateMap<Brand, BrandModel>();
                config.CreateMap<Supplier, SupplierModel>();
                config.CreateMap<ColorCode, ColorCodeModel>();

                config.CreateMap<CarModel, CarModelModel>();
                config.CreateMap<CarBodyType, CarBodyTypeModel>();
                config.CreateMap<ModelSupportsBodyType, CarBodyTypeWithPriceModel>()
                    .ForCtorParam("id", opt => opt.MapFrom(src => src.BodyType.Id))
                    .ForCtorParam("name", opt => opt.MapFrom(src => src.BodyType.Name));
                config.CreateMap<CarEngineType, CarEngineTypeModel>();
                config.CreateMap<Gearbox, GearboxModel>();
                config.CreateMap<CarEngine, CarEngineModel>();
                #endregion
            }).CreateMapper();
        }
    }
}

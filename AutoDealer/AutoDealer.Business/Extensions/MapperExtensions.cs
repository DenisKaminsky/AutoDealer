using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Models.Responses.Miscellaneous;
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
                    //.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => new Brand { Id = src.BrandId }));
                    config.CreateMap<SupplierUpdateCommand, Supplier>();
                    //.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => new Brand { Id = src.BrandId }));
                #endregion

                #region Responses
                config.CreateMap<Country, CountryModel>();
                config.CreateMap<Brand, BrandModel>();
                config.CreateMap<Supplier, SupplierModel>();
                #endregion
            }).CreateMapper();
        }
    }
}

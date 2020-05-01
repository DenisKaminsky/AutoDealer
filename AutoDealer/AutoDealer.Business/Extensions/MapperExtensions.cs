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

                #endregion

                #region Responses
                config.CreateMap<Country, CountryModel>();
                config.CreateMap<CountryCreateCommand, Country>();
                config.CreateMap<CountryUpdateCommand, Country>();
                config.CreateMap<Brand, BrandModel>();
                #endregion
            }).CreateMapper();
        }
    }
}

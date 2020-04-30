using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;
using AutoMapper;

namespace AutoDealer.Web.Extensions
{
    public static class MapperExtensions
    {
        public static IMapper GetMapper()
        {
            return new MapperConfiguration(config =>
            {

                #region Miscellaneous
                config.CreateMap<CountryModel, CountryViewModel>();
                #endregion
            }).CreateMapper();
        }
    }
}

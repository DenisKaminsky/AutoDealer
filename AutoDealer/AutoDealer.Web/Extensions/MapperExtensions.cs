﻿using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Web.ViewModels.Request.Car;
using AutoDealer.Web.ViewModels.Request.Miscellaneous;
using AutoDealer.Web.ViewModels.Response.Car;
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
                #region System
                config.CreateMap<string, string>()
                    .ConstructUsing(str => str != null ? str.Trim() : str);
                #endregion

                #region Car
                config.CreateMap<CarModelModel, CarModelViewModel>();
                config.CreateMap<CarBodyTypeWithPriceModel, CarBodyTypeWithPriceViewModel>();
                config.CreateMap<CarModelCreateViewModel, CarModelCreateCommand>();
                config.CreateMap<CarModelUpdateViewModel, CarModelUpdateCommand>();

                config.CreateMap<CarBodyTypeModel, CarBodyTypeViewModel>();
                config.CreateMap<CarBodyTypeCreateViewModel, CarBodyTypeCreateCommand>();
                config.CreateMap<CarBodyTypeAssignViewModel, CarBodyTypeAssignCommand>();
                config.CreateMap<CarBodyTypeUnassignViewModel, CarBodyTypeUnassignCommand>();
                #endregion

                #region Miscellaneous
                config.CreateMap<CountryModel, CountryViewModel>();
                config.CreateMap<CountryCreateViewModel, CountryCreateCommand>();
                config.CreateMap<CountryUpdateViewModel, CountryUpdateCommand>();
                config.CreateMap<BrandModel, BrandViewModel>();
                config.CreateMap<BrandCreateViewModel, BrandCreateCommand>();
                config.CreateMap<BrandUpdateViewModel, BrandUpdateCommand>();
                config.CreateMap<SupplierModel, SupplierViewModel>();
                config.CreateMap<SupplierCreateViewModel, SupplierCreateCommand>();
                config.CreateMap<SupplierUpdateViewModel, SupplierUpdateCommand>();
                config.CreateMap<ColorCodeModel, ColorCodeViewModel>();
                #endregion
            }).CreateMapper();
        }
    }
}

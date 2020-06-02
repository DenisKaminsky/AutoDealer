using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Business.Models.Responses.Order;
using AutoDealer.Business.Models.Responses.User;
using AutoDealer.Business.Models.Responses.WorkOrder;
using AutoDealer.Web.ViewModels.Base;
using AutoDealer.Web.ViewModels.Request.Car;
using AutoDealer.Web.ViewModels.Request.Miscellaneous;
using AutoDealer.Web.ViewModels.Request.Order;
using AutoDealer.Web.ViewModels.Request.User;
using AutoDealer.Web.ViewModels.Request.WorkOrder;
using AutoDealer.Web.ViewModels.Response.Car;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;
using AutoDealer.Web.ViewModels.Response.Order;
using AutoDealer.Web.ViewModels.Response.User;
using AutoDealer.Web.ViewModels.Response.WorkOrder;
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
                config.CreateMap<CarModelCarStockModel, CarModelCarStockViewModel>();
                config.CreateMap<CarModelCreateViewModel, CarModelCreateCommand>();
                config.CreateMap<CarModelUpdateViewModel, CarModelUpdateCommand>();

                config.CreateMap<CarBodyTypeModel, CarBodyTypeViewModel>();
                config.CreateMap<CarBodyTypeCreateViewModel, CarBodyTypeCreateCommand>();
                config.CreateMap<CarBodyTypeAssignViewModel, CarBodyTypeAssignCommand>();
                config.CreateMap<CarBodyTypeUnassignViewModel, CarBodyTypeUnassignCommand>();
                config.CreateMap<CarBodyTypeWithPriceModel, CarBodyTypeWithPriceViewModel>();

                config.CreateMap<CarColorAssignmentViewModel, CarColorAssignmentCommand>();

                config.CreateMap<CarEngineTypeModel, CarEngineTypeViewModel>();
                config.CreateMap<CarEngineTypeCreateViewModel, CarEngineTypeCreateCommand>();

                config.CreateMap<GearboxModel, GearboxViewModel>();
                config.CreateMap<GearboxCreateViewModel, GearboxCreateCommand>();

                config.CreateMap<CarEngineModel, CarEngineViewModel>();
                config.CreateMap<CarEngineCreateViewModel, CarEngineCreateCommand>();
                config.CreateMap<CarEngineUpdateViewModel, CarEngineUpdateCommand>();

                config.CreateMap<CarEngineWithGearboxModel, CarEngineGearboxViewModel>();
                config.CreateMap<CarEngineWithGearboxModel, CarModelEngineGearboxViewModel>();
                config.CreateMap<CarEngineGearboxAssignViewModel, CarEngineGearboxAssignCommand>();
                config.CreateMap<CarEngineGearboxUnassignViewModel, CarEngineGearboxUnassignCommand>();

                config.CreateMap<CarComplectationModel, CarComplectationViewModel>();
                config.CreateMap<CarComplectationCarStockModel, CarComplectationCarStockViewModel>();
                config.CreateMap<CarComplectationCreateViewModel, CarComplectationCreateCommand>();

                config.CreateMap<CarComplectationOptionModel, CarComplectationOptionViewModel>();
                config.CreateMap<CarComplectationOptionsAssignViewModel, CarComplectationOptionsAssignCommand>();

                config.CreateMap<CarStockModel, CarStockViewModel>();
                config.CreateMap<CarStockCreateViewModel, CarStockCreateCommand>();
                config.CreateMap<CarStockUpdateViewModel, CarStockUpdateCommand>();

                config.CreateMap<CarPhotoCreateViewModel, CarPhotoCreateCommand>()
                    .ForMember(dest => dest.Photo, opt => opt
                        .MapFrom(src => src.Photo != null ? new FileAttachment(src.Photo) : null));
                #endregion

                #region User
                config.CreateMap<UserModel, UserViewModel>();
                config.CreateMap<UserRoleModel, UserRoleViewModel>();
                config.CreateMap<UserCreateViewModel, UserCreateCommand>()
                    .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Date));
                config.CreateMap<UserUpdateViewModel, UserUpdateCommand>()
                    .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Date));
                config.CreateMap<UserUpdateActiveStatusViewModel, UserUpdateActiveStatusCommand>();
                config.CreateMap<UserResetPasswordViewModel, UserResetPasswordCommand>();
                config.CreateMap<LogInVewModel, LogInInfo>();
                config.CreateMap<UserContactInfo, UserContactInfoViewModel>();

                config.CreateMap<ClientModel, ClientViewModel>();
                config.CreateMap<ClientCreateViewModel, ClientCreateCommand>()
                    .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Date));
                config.CreateMap<ClientUpdateViewModel, ClientUpdateCommand>()
                    .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Date));
                #endregion

                #region WorkOrder
                config.CreateMap<WorkOrderClientModel, WorkOrderClientViewModel>();
                config.CreateMap<WorkOrderClientCreateViewModel, WorkOrderClientCreateCommand>();
                config.CreateMap<WorkOrderClientUpdateViewModel, WorkOrderClientUpdateCommand>();

                config.CreateMap<WorkOrderStatusModel, WorkOrderStatusViewModel>();

                config.CreateMap<WorkModel, WorkViewModel>();
                config.CreateMap<WorkCreateViewModel, WorkCreateCommand>();

                config.CreateMap<WorkOrderModel, WorkOrderViewModel>();
                config.CreateMap<WorkOrderCreateViewModel, WorkOrderCreateCommand>();
                config.CreateMap<WorkOrderCreateAdminViewModel, WorkOrderCreateCommand>();
                #endregion

                #region Order
                config.CreateMap<OrderStatusModel, OrderStatusViewModel>();
                config.CreateMap<DeliveryRequestStatusModel, DeliveryRequestStatusViewModel>();
                config.CreateMap<DeliveryRequestModel, DeliveryRequestViewModel>();
                config.CreateMap<DeliveryRequestCreateViewModel, DeliveryRequestCreateCommand>();
                config.CreateMap<DeliveryRequestCreateAdminViewModel, DeliveryRequestCreateCommand>();
                config.CreateMap<OrderModel, OrderViewModel>();
                
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
                config.CreateMap<ColorCodeCreateViewModel, ColorCodeCreateCommand>();
                config.CreateMap<SupplierPhotoCreateViewModel, SupplierPhotoCreateCommand>()
                    .ForMember(dest => dest.Photo, opt => opt
                        .MapFrom(src => src.Photo != null ? new FileAttachment(src.Photo) : null));
                #endregion
            }).CreateMapper();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.Models.Order;
using AutoDealer.Data.Models.User;
using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Data.Models.WorkOrder.Relations;
using AutoDealer.Miscellaneous.Enums;
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
                config.CreateMap<CarEngineGearboxAssignCommand, EngineSupportsGearbox>();
                config.CreateMap<CarComplectationCreateCommand, CarComplectation>();
                config.CreateMap<CarComplectationOptionsAssignCommand, IEnumerable<CarComplectationOption>>()
                    .ConstructUsing(src => src.Options
                        .Select(x => new CarComplectationOption { ComplectationId = src.ComplectationId, Name = x }));
                config.CreateMap<CarStockCreateCommand, CarStock>()
                    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => 0));
                config.CreateMap<CarStockUpdateCommand, CarStock>();

                config.CreateMap<UserCreateCommand, User>()
                    .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow.Date))
                    .ForMember(x => x.IsActive, opt => opt.MapFrom(src => true));
                config.CreateMap<ClientCreateCommand, Client>();
                config.CreateMap<ClientUpdateCommand, Client>();

                config.CreateMap<WorkOrderClientCreateCommand, WorkOrderClient>();
                config.CreateMap<WorkOrderClientUpdateCommand, WorkOrderClient>();
                config.CreateMap<WorkCreateCommand, Work>();
                config.CreateMap<WorkOrderCreateCommand, WorkOrder>()
                    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow.Date))
                    .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)WorkOrderStatuses.InProgress))
                    .ForMember(dest => dest.Works, opt => opt.MapFrom(src => src.WorksIds.Distinct().Select(x => new WorkOrderHasWorks { WorkId = x })));

                config.CreateMap<DeliveryRequestFromStockCreateCommand, DeliveryRequest>()
                    .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow.Date))
                    .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)DeliveryRequestStatuses.Opened));
                #endregion

                #region Responses
                config.CreateMap<Country, CountryModel>();
                config.CreateMap<Brand, BrandModel>();
                config.CreateMap<Supplier, SupplierModel>()
                    .ForCtorParam("photos", opt => opt.MapFrom(src => src.Photos.Select(x => x.Id)));
                config.CreateMap<ColorCode, ColorCodeModel>();

                config.CreateMap<CarModel, CarModelModel>();
                config.CreateMap<CarModel, CarModelCarStockModel>();
                config.CreateMap<CarBodyType, CarBodyTypeModel>();
                config.CreateMap<ModelSupportsBodyType, CarBodyTypeWithPriceModel>()
                    .ForCtorParam("id", opt => opt.MapFrom(src => src.BodyType.Id))
                    .ForCtorParam("name", opt => opt.MapFrom(src => src.BodyType.Name));
                config.CreateMap<CarEngineType, CarEngineTypeModel>();
                config.CreateMap<Gearbox, GearboxModel>();
                config.CreateMap<CarEngine, CarEngineModel>();
                config.CreateMap<EngineSupportsGearbox, CarEngineWithGearboxModel>();
                config.CreateMap<CarComplectation, CarComplectationModel>();
                config.CreateMap<CarComplectation, CarComplectationCarStockModel>();
                config.CreateMap<CarComplectationOption, CarComplectationOptionModel>();
                config.CreateMap<CarStock, CarStockModel>()
                    .ForCtorParam("gearbox", opt => opt.MapFrom(src => src.EngineGearbox.Gearbox))
                    .ForCtorParam("engine", opt => opt.MapFrom(src => src.EngineGearbox.Engine));

                config.CreateMap<User, UserModel>();
                config.CreateMap<UserRole, UserRoleModel>();
                config.CreateMap<User, UserSignInModel>();
                config.CreateMap<User, UserContactInfo>();
                config.CreateMap<Client, ClientModel>();

                config.CreateMap<WorkOrderClient, WorkOrderClientModel>();
                config.CreateMap<WorkOrderStatus, WorkOrderStatusModel>();
                config.CreateMap<Work, WorkModel>();
                config.CreateMap<WorkOrder, WorkOrderModel>()
                    .ForCtorParam("works", opt => opt.MapFrom(src => src.Works.Select(x => x.Work)));

                config.CreateMap<OrderStatus, OrderStatusModel>();
                config.CreateMap<DeliveryRequestStatus, DeliveryRequestStatusModel>();
                config.CreateMap<DeliveryRequest, DeliveryRequestModel>()
                    .ForCtorParam("supplierId", opt => opt.MapFrom(src => src.Car.Model.Brand.SupplierId));

                config.CreateMap<Order, OrderModel>();
                #endregion
            }).CreateMapper();
        }
    }
}

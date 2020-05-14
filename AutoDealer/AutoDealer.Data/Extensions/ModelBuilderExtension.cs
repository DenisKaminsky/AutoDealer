using AutoDealer.Data.ModelsConfigurations.Car;
using AutoDealer.Data.ModelsConfigurations.Car.Relations;
using AutoDealer.Data.ModelsConfigurations.Miscellaneous;
using AutoDealer.Data.ModelsConfigurations.Order;
using AutoDealer.Data.ModelsConfigurations.User;
using AutoDealer.Data.ModelsConfigurations.WokOrder;
using AutoDealer.Data.ModelsConfigurations.WokOrder.Relations;
using AutoDealer.Data.Seeds.Car;
using AutoDealer.Data.Seeds.Car.Relations;
using AutoDealer.Data.Seeds.Miscellaneous;
using AutoDealer.Data.Seeds.Order;
using AutoDealer.Data.Seeds.User;
using AutoDealer.Data.Seeds.WorkOrder;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Car
            modelBuilder.SeedCarModels();
            modelBuilder.SeedCarBodyTypes();
            modelBuilder.SeedModelSupportsBodyType();
            modelBuilder.SeedModelsSupportColors();
            modelBuilder.SeedCarEngineTypes();
            modelBuilder.SeedGearboxes();
            modelBuilder.SeedCarEngines();
            modelBuilder.SeedEnginesSupportGearboxes();
            modelBuilder.SeedCarComplectations();
            modelBuilder.SeedCarsStock();
            #endregion

            #region User
            modelBuilder.SeedUserRoles();
            modelBuilder.SeedUsers();
            #endregion

            #region WorkOrder
            modelBuilder.SeedWorkOrderStatuses();
            modelBuilder.SeedWorks();
            #endregion

            #region Order
            modelBuilder.SeedOrderStatuses();
            modelBuilder.SeedDeliveryRequestStatus();
            #endregion

            #region Miscellaneous
            modelBuilder.SeedBrands();
            modelBuilder.SeedCountries();
            modelBuilder.SeedSuppliers();
            modelBuilder.SeedColorCodes();
            #endregion
        }

        public static void ConfigureModels(this ModelBuilder modelBuilder)
        {
            #region Car
            modelBuilder.ConfigureCarModel();
            modelBuilder.ConfigureCarBodyType();
            modelBuilder.ConfigureModelSupportsBodyType();
            modelBuilder.ConfigureModelSupportsColor();
            modelBuilder.ConfigureCarEngineType();
            modelBuilder.ConfigureGearbox();
            modelBuilder.ConfigureCarEngine();
            modelBuilder.ConfigureEngineSupportsGearbox();
            modelBuilder.ConfigureCarComplectation();
            modelBuilder.ConfigureCarComplectationOption();
            modelBuilder.ConfigureCarStock();
            modelBuilder.ConfigureCarPhoto();
            #endregion

            #region User
            modelBuilder.ConfigureUser();
            modelBuilder.ConfigureUserRole();
            modelBuilder.ConfigureClient();
            #endregion

            #region WorkOrder
            modelBuilder.ConfigureWorkOrderClient();
            modelBuilder.ConfigureWorkOrderStatus();
            modelBuilder.ConfigureWork();
            modelBuilder.ConfigureWorkOrder();
            modelBuilder.ConfigureWorkOrderHasWorks();
            #endregion

            #region Order
            modelBuilder.ConfigureOrderStatus();
            modelBuilder.ConfigureDeliveryRequestStatus();
            modelBuilder.ConfigureDeliveryRequest();
            #endregion

            #region Miscellaneous
            modelBuilder.ConfigureBrand();
            modelBuilder.ConfigureCountry();
            modelBuilder.ConfigureSupplier();
            modelBuilder.ConfigureColorCode();
            #endregion
        }
    }
}

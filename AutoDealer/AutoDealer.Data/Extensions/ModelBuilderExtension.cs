﻿using AutoDealer.Data.ModelsConfigurations.Car;
using AutoDealer.Data.ModelsConfigurations.Car.Relations;
using AutoDealer.Data.ModelsConfigurations.Miscellaneous;
using AutoDealer.Data.ModelsConfigurations.User;
using AutoDealer.Data.ModelsConfigurations.WokOrder;
using AutoDealer.Data.Seeds.Car;
using AutoDealer.Data.Seeds.Car.Relations;
using AutoDealer.Data.Seeds.Miscellaneous;
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

            #region MyRegion
            modelBuilder.SeedWorkOrderStatuses();
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
            #endregion

            #region User
            modelBuilder.ConfigureUser();
            modelBuilder.ConfigureUserRole();
            modelBuilder.ConfigureClient();
            #endregion

            #region WorkOrder
            modelBuilder.ConfigureWorkOrderClient();
            modelBuilder.ConfigureWorkOrderStatus();
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

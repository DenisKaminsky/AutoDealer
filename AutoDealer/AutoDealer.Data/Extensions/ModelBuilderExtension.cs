using AutoDealer.Data.ModelsConfigurations.Car;
using AutoDealer.Data.ModelsConfigurations.Car.Relations;
using AutoDealer.Data.ModelsConfigurations.Miscellaneous;
using AutoDealer.Data.Seeds.Car;
using AutoDealer.Data.Seeds.Car.Relations;
using AutoDealer.Data.Seeds.Miscellaneous;
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

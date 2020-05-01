using AutoDealer.Data.ModelsConfigurations.Miscellaneous;
using AutoDealer.Data.Seeds.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            #region Miscellaneous
            modelBuilder.SeedBrands();
            modelBuilder.SeedCountries();
            modelBuilder.SeedSuppliers();
            #endregion
        }

        public static void ConfigureModels(this ModelBuilder modelBuilder)
        {


            #region Miscellaneous
            modelBuilder.ConfigureBrand();
            modelBuilder.ConfigureCountry();
            modelBuilder.ConfigureSupplier();
            #endregion
        }
    }
}

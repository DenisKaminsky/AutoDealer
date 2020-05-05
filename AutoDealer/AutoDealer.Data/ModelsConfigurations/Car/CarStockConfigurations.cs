using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarStockConfigurations
    {
        public static void ConfigureCarStock(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarStock>()
                .HasCheckConstraint("CK_CarsStock_Price", $"\"{nameof(CarStock.Price)}\" >= 0");

            modelBuilder.Entity<CarStock>()
                .HasCheckConstraint("CK_CarsStock_Amount", $"\"{nameof(CarStock.Amount)}\" >= 0");
        }
    }
}

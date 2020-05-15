using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarStockConfigurations
    {
        public static void ConfigureCarStock(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarStock>()
                .HasIndex(x => new { x.ModelId, x.BodyTypeId, x.ColorId, x.EngineGearboxId, x.ComplectationId })
                .IsUnique();

            modelBuilder.Entity<CarStock>()
                .HasCheckConstraint("CK_CarsStock_Price", $"\"{nameof(CarStock.Price)}\" >= 0");

            modelBuilder.Entity<CarStock>()
                .HasCheckConstraint("CK_CarsStock_Amount", $"\"{nameof(CarStock.Amount)}\" >= 0");
        }
    }
}

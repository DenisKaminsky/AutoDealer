using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarEngineTypeConfigurations
    {
        public static void ConfigureCarEngineType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEngineType>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<CarEngineType>()
                .Property(x => x.Name)
                .HasMaxLength(CarEngineTypeConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}

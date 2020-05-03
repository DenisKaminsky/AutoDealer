using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarEngineConfigurations
    {
        public static void ConfigureCarEngine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEngine>()
                .Property(x => x.Name)
                .HasMaxLength(CarEngineConstraints.NameMaxLength)
                .IsRequired();

            modelBuilder.Entity<CarEngine>()
                .HasCheckConstraint("CK_CarEngine_Volume", $"\"{nameof(CarEngine.Volume)}\" >= 0");

            modelBuilder.Entity<CarEngine>()
                .HasCheckConstraint("CK_CarEngine_Power", $"\"{nameof(CarEngine.Power)}\" >= 0");
        }
    }
}

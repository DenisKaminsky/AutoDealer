using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarComplectationConfigurations
    {
        public static void ConfigureCarComplectation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarComplectation>()
                .Property(x => x.Name)
                .HasMaxLength(CarComplectationConstraints.NameMaxLength)
                .IsRequired();

            modelBuilder.Entity<CarEngine>()
                .HasCheckConstraint("CK_CarComplectation_Price", $"\"{nameof(CarComplectation.Price)}\" >= 0");
        }
    }
}

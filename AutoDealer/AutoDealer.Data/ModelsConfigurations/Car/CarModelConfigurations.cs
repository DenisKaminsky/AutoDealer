using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarModelConfigurations
    {
        public static void ConfigureCarModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<CarModel>()
                .Property(x => x.Name)
                .HasMaxLength(CarModelConstraints.NameMaxLength)
                .IsRequired();

            modelBuilder.Entity<CarModel>()
                .HasCheckConstraint("CK_CarModel_Price", $"\"{nameof(CarModel.Price)}\" >= 0");
        }
    }
}

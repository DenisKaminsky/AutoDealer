using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarBodyTypeConfigurations
    {
        public static void ConfigureCarBodyType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBodyType>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<CarBodyType>()
                .Property(x => x.Name)
                .HasMaxLength(CarBodyTypeConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}

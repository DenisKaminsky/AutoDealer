using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarComplectationOptionConfigurations
    {
        public static void ConfigureCarComplectationOption(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarComplectationOption>()
                .Property(x => x.Name)
                .HasMaxLength(CarComplectationOptionConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}

using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class GearboxConfigurations
    {
        public static void ConfigureGearbox(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gearbox>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Gearbox>()
                .Property(x => x.Name)
                .HasMaxLength(GearboxConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}

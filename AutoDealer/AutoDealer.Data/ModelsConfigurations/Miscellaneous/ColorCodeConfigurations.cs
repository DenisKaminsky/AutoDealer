using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Miscellaneous
{
    public static class ColorCodeConfigurations
    {
        public static void ConfigureColorCode(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColorCode>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<ColorCode>()
                .Property(x => x.Name)
                .HasMaxLength(ColorCodeConstraints.NameMaxLength)
                .IsRequired();

            modelBuilder.Entity<ColorCode>()
                .Property(x => x.HexValue)
                .HasMaxLength(ColorCodeConstraints.HexValueLength)
                .IsRequired();
        }
    }
}

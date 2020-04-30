using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Constraints.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Miscellaneous
{
    public static class CountryConfigurations
    {
        public static void ConfigureCountry(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .Property(x => x.Name)
                .HasMaxLength(CountyConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}

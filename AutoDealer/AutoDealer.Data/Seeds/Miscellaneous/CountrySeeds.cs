using System.Linq;
using AutoDealer.Data.Models.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Miscellaneous
{
    public static class CountrySeeds
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            var countries = new[]
            {
                new Country { Id = 1, Name = "Austria" },
                new Country { Id = 2, Name = "Australia" },
                new Country { Id = 3, Name = "Belarus" },
                new Country { Id = 4, Name = "Czechia" },
                new Country { Id = 5, Name = "China" },
                new Country { Id = 6, Name = "Finland" },
                new Country { Id = 7, Name = "France" },
                new Country { Id = 8, Name = "Germany" },
                new Country { Id = 9, Name = "Japan" },
                new Country { Id = 10, Name = "Italy" },
                new Country { Id = 11, Name = "Russia" },
                new Country { Id = 12, Name = "South Korea" },
                new Country { Id = 13, Name = "Sweden" },
                new Country { Id = 14, Name = "United Kingdom of Great Britain and Northern Ireland" },
                new Country { Id = 15, Name = "United States of America" }
            };

            modelBuilder.Entity<Country>().HasData(countries);

            modelBuilder.HasSequence<int>("Countries_Seq", schema: "public")
                .StartsAt(countries.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Country>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Countries_Seq\"')");
        }
    }
}

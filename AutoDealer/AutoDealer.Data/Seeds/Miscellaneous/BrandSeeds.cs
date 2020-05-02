using System.Linq;
using AutoDealer.Data.Models.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Miscellaneous
{
    public static class BrandSeeds
    {
        public static void SeedBrands(this ModelBuilder modelBuilder)
        {
            var brands = new []
            {
                new Brand {Id = 1, Name = "Aston Martin", CountryId = 14, SupplierId = 1 },
                new Brand {Id = 2, Name = "Audi", CountryId = 8, SupplierId = 2 },
                new Brand {Id = 3, Name = "Bentley", CountryId = 14, SupplierId = 3 },
                new Brand {Id = 4, Name = "BMW", CountryId = 8, SupplierId = 4 },
                new Brand {Id = 5, Name = "Cadillac", CountryId = 15, SupplierId = 5 },
                new Brand {Id = 6, Name = "Ferrari", CountryId = 10, SupplierId = null },
                new Brand {Id = 7, Name = "Land Rover", CountryId = 14, SupplierId = 6 },
                new Brand {Id = 8, Name = "Mercedes-Benz", CountryId = 8, SupplierId = 7 },
                new Brand {Id = 9, Name = "Porsche", CountryId = 8, SupplierId = 8 },
                new Brand {Id = 10, Name = "Rolls-Royce", CountryId = 14, SupplierId = null },
                new Brand {Id = 11, Name = "Tesla", CountryId = 15, SupplierId = null },
                new Brand {Id = 12, Name = "Volkswagen", CountryId = 8, SupplierId = 9 },
            };

            modelBuilder.Entity<Brand>().HasData(brands);

            modelBuilder.HasSequence<int>("Brands_Seq", schema: "public")
                .StartsAt(brands.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Brand>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Brands_Seq\"')");
        }
    }
}

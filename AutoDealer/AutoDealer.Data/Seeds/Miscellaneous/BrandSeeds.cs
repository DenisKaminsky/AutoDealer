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
                new Brand {Id = 6, Name = "Chevrolet", CountryId = 15, SupplierId = 6 },
                new Brand {Id = 7, Name = "Dodge", CountryId = 15, SupplierId = null },
                new Brand {Id = 8, Name = "Ferrari", CountryId = 10, SupplierId = null },
                new Brand {Id = 9, Name = "Ford", CountryId = 15, SupplierId = 9 },
                new Brand {Id = 10, Name = "Hyundai", CountryId = 12, SupplierId = 10 },
                new Brand {Id = 11, Name = "Jaguar", CountryId = 14, SupplierId = 11 },
                new Brand {Id = 12, Name = "Jeep", CountryId = 15, SupplierId = 12 },
                new Brand {Id = 13, Name = "Kia", CountryId = 12, SupplierId = 13 },
                new Brand {Id = 14, Name = "Land Rover", CountryId = 14, SupplierId = 14 },
                new Brand {Id = 15, Name = "Lexus", CountryId = 9, SupplierId = 15 },
                new Brand {Id = 16, Name = "Mazda", CountryId = 9, SupplierId = 16 },
                new Brand {Id = 17, Name = "Mercedes-Benz", CountryId = 8, SupplierId = 17 },
                new Brand {Id = 18, Name = "Mini", CountryId = 14, SupplierId = 18 },
                new Brand {Id = 19, Name = "Mitsubishi", CountryId = 9, SupplierId = 19 },
                new Brand {Id = 20, Name = "Peugeot", CountryId = 7, SupplierId = 20 },
                new Brand {Id = 21, Name = "Porsche", CountryId = 8, SupplierId = 21 },
                new Brand {Id = 22, Name = "Renault", CountryId = 7, SupplierId = 22 },
                new Brand {Id = 23, Name = "Rolls-Royce", CountryId = 14, SupplierId = null },
                new Brand {Id = 24, Name = "Skoda", CountryId = 4, SupplierId = 24 },
                new Brand {Id = 25, Name = "Tesla", CountryId = 15, SupplierId = 25 },
                new Brand {Id = 26, Name = "Toyota", CountryId = 9, SupplierId = 26 },
                new Brand {Id = 27, Name = "Volkswagen", CountryId = 8, SupplierId = 27 },
                new Brand {Id = 28, Name = "Volvo", CountryId = 13, SupplierId = 28 }
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

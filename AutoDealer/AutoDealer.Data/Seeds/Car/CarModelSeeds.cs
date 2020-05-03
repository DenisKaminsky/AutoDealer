using System.Linq;
using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class CarModelSeeds
    {
        public static void SeedCarModels(this ModelBuilder modelBuilder)
        {
            var carModels = new[]
            {
               new CarModel { Id = 1, Name = "DB 11", BrandId = 1, Price = 253000 },
               new CarModel { Id = 2, Name = "V8 Vantage", BrandId = 1, Price = 171000 },
               new CarModel { Id = 3, Name = "DBX", BrandId = 1, Price = 250000 },
               new CarModel { Id = 4, Name = "A4", BrandId = 2, Price = 29700 },
               new CarModel { Id = 5, Name = "A6", BrandId = 2, Price = 47000 },
               new CarModel { Id = 6, Name = "Q7", BrandId = 2, Price = 81300 },
               new CarModel { Id = 7, Name = "Bentayga", BrandId = 3, Price = 197000 },
               new CarModel { Id = 8, Name = "Continental GT", BrandId = 3, Price = 230750 },
               new CarModel { Id = 9, Name = "X3", BrandId = 4, Price = 43400 },
               new CarModel { Id = 10, Name = "X5", BrandId = 4, Price = 67300 },
               new CarModel { Id = 11, Name = "X7", BrandId = 4, Price = 99100 },
               new CarModel { Id = 12, Name = "Escalade", BrandId = 5, Price = 74000 },
               new CarModel { Id = 13, Name = "CT6", BrandId = 5, Price = 55700 },
               new CarModel { Id = 14, Name = "488", BrandId = 6, Price = 425500 },
               new CarModel { Id = 15, Name = "812", BrandId = 6, Price = 411130 },
               new CarModel { Id = 16, Name = "Range Rover Evoque", BrandId = 7, Price = 53100 },
               new CarModel { Id = 17, Name = "Range Rover Velar", BrandId = 7, Price = 61000 },
               new CarModel { Id = 18, Name = "S-Class", BrandId = 8, Price = 153000 },
               new CarModel { Id = 19, Name = "GLS", BrandId = 8, Price = 99700 },
               new CarModel { Id = 20, Name = "SLS GT", BrandId = 8, Price = 385000 },
               new CarModel { Id = 21, Name = "Cayenne", BrandId = 9, Price = 91200 },
               new CarModel { Id = 22, Name = "Macan", BrandId = 9, Price = 62000 },
               new CarModel { Id = 23, Name = "Ghost", BrandId = 10, Price = 287300 },
               new CarModel { Id = 24, Name = "Wraith", BrandId = 10, Price = 310400 },
               new CarModel { Id = 25, Name = "Model X", BrandId = 11, Price = 118500 },
               new CarModel { Id = 26, Name = "Model S", BrandId = 11, Price = 114500 },
               new CarModel { Id = 27, Name = "Polo", BrandId = 12, Price = 11200 },
               new CarModel { Id = 28, Name = "Passat", BrandId = 12, Price = 25000 },
            };

            modelBuilder.Entity<CarModel>().HasData(carModels);

            modelBuilder.HasSequence<int>("CarModels_Seq", schema: "public")
                .StartsAt(carModels.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<CarModel>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"CarModels_Seq\"')");
        }
    }
}

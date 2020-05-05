using System.Linq;
using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class CarStockSeeds
    {
        public static void SeedCarsStock(this ModelBuilder modelBuilder)
        {
            var cars = new[]
            {
                new CarStock {Id = 1, ModelId = 1, BodyTypeId = 7, ColorId = 3, EngineGearboxId = 2, ComplectationId = 1, Amount = 1, Price = 253000 },
                new CarStock {Id = 2, ModelId = 2, BodyTypeId = 4, ColorId = 4, EngineGearboxId = 3, ComplectationId = 2, Amount = 3, Price = 171000 },
                new CarStock {Id = 3, ModelId = 3, BodyTypeId = 8, ColorId = 1, EngineGearboxId = 4, ComplectationId = 3, Amount = 2, Price = 250000 },
                new CarStock {Id = 4, ModelId = 4, BodyTypeId = 1, ColorId = 5, EngineGearboxId = 9, ComplectationId = 6, Amount = 4, Price = 29700 },
                new CarStock {Id = 5, ModelId = 5, BodyTypeId = 1, ColorId = 6, EngineGearboxId = 12, ComplectationId = 10, Amount = 1, Price = 47000 },
                new CarStock {Id = 6, ModelId = 6, BodyTypeId = 8, ColorId = 8, EngineGearboxId = 14, ComplectationId = 12, Amount = 2, Price = 81300 },
                new CarStock {Id = 7, ModelId = 7, BodyTypeId = 8, ColorId = 9, EngineGearboxId = 15, ComplectationId = 14, Amount = 3, Price = 197000 },
                new CarStock {Id = 8, ModelId = 8, BodyTypeId = 4, ColorId = 9, EngineGearboxId = 20, ComplectationId = 15, Amount = 4, Price = 230750 },
                new CarStock {Id = 9, ModelId = 9, BodyTypeId = 8, ColorId = 1, EngineGearboxId = 24, ComplectationId = 18, Amount = 2, Price = 43400 },
                new CarStock {Id = 10, ModelId = 10, BodyTypeId = 8, ColorId = 2, EngineGearboxId = 27, ComplectationId = 20, Amount = 3, Price = 67300 },
                new CarStock {Id = 11, ModelId = 11, BodyTypeId = 8, ColorId = 2, EngineGearboxId = 33, ComplectationId = 24, Amount = 4, Price = 99100 },
                new CarStock {Id = 12, ModelId = 12, BodyTypeId = 8, ColorId = 4, EngineGearboxId = 35, ComplectationId = 29, Amount = 5, Price = 74000 },
                new CarStock {Id = 13, ModelId = 13, BodyTypeId = 1, ColorId = 8, EngineGearboxId = 37, ComplectationId = 30, Amount = 1, Price = 55700 },
                new CarStock {Id = 14, ModelId = 14, BodyTypeId = 7, ColorId = 7, EngineGearboxId = 38, ComplectationId = 32, Amount = 2, Price = 425500 },
                new CarStock {Id = 15, ModelId = 15, BodyTypeId = 4, ColorId = 6, EngineGearboxId = 39, ComplectationId = 33, Amount = 4, Price = 411130 },
                new CarStock {Id = 16, ModelId = 16, BodyTypeId = 8, ColorId = 3, EngineGearboxId = 43, ComplectationId = 36, Amount = 3, Price = 53100 },
                new CarStock {Id = 17, ModelId = 17, BodyTypeId = 8, ColorId = 5, EngineGearboxId = 47, ComplectationId = 38, Amount = 1, Price = 61000 },
                new CarStock {Id = 18, ModelId = 18, BodyTypeId = 1, ColorId = 1, EngineGearboxId = 52, ComplectationId = 42, Amount = 2, Price = 153000 },
                new CarStock {Id = 19, ModelId = 19, BodyTypeId = 8, ColorId = 8, EngineGearboxId = 54, ComplectationId = 45, Amount = 3, Price = 99700 },
                new CarStock {Id = 20, ModelId = 20, BodyTypeId = 7, ColorId = 2, EngineGearboxId = 55, ComplectationId = 47, Amount = 4, Price = 385000 },
                new CarStock {Id = 21, ModelId = 21, BodyTypeId = 8, ColorId = 3, EngineGearboxId = 59, ComplectationId = 48, Amount = 2, Price = 91200 },
                new CarStock {Id = 22, ModelId = 22, BodyTypeId = 8, ColorId = 4, EngineGearboxId = 63, ComplectationId = 52, Amount = 3, Price = 62000 },
                new CarStock {Id = 23, ModelId = 23, BodyTypeId = 1, ColorId = 2, EngineGearboxId = 65, ComplectationId = 54, Amount = 4, Price = 287300 },
                new CarStock {Id = 24, ModelId = 24, BodyTypeId = 4, ColorId = 5, EngineGearboxId = 66, ComplectationId = 55, Amount = 1, Price = 310400 },
                new CarStock {Id = 25, ModelId = 25, BodyTypeId = 8, ColorId = 2, EngineGearboxId = 68, ComplectationId = 56, Amount = 5, Price = 118500 },
                new CarStock {Id = 26, ModelId = 26, BodyTypeId = 2, ColorId = 4, EngineGearboxId = 70, ComplectationId = 57, Amount = 2, Price = 114500 },
                new CarStock {Id = 27, ModelId = 27, BodyTypeId = 1, ColorId = 1, EngineGearboxId = 76, ComplectationId = 61, Amount = 6, Price = 11200 },
                new CarStock {Id = 28, ModelId = 28, BodyTypeId = 1, ColorId = 6, EngineGearboxId = 82, ComplectationId = 63, Amount = 3, Price = 25000 },
            };

            modelBuilder.Entity<CarStock>().HasData(cars);

            modelBuilder.HasSequence<int>("CarsStock_Seq", schema: "public")
                .StartsAt(cars.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<CarStock>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"CarsStock_Seq\"')");
        }
    }
}

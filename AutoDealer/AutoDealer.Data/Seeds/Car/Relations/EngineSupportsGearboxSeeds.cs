using System.Linq;
using AutoDealer.Data.Models.Car.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car.Relations
{
    public static class EngineSupportsGearboxSeeds
    {
        public static void SeedEnginesSupportGearboxes(this ModelBuilder modelBuilder)
        {
            var engineGearboxes = new[]
            {
                new EngineSupportsGearbox { Id = 1, ModelId = 1, EngineId = 1, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 2, ModelId = 1, EngineId = 2, GearboxId = 1, Price = 23800 },
                new EngineSupportsGearbox { Id = 3, ModelId = 2, EngineId = 3, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 4, ModelId = 3, EngineId = 4, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 5, ModelId = 4, EngineId = 5, GearboxId = 3 },
                new EngineSupportsGearbox { Id = 6, ModelId = 4, EngineId = 6, GearboxId = 3, Price = 5900 },
                new EngineSupportsGearbox { Id = 7, ModelId = 4, EngineId = 7, GearboxId = 3, Price = 12100 },
                new EngineSupportsGearbox { Id = 8, ModelId = 4, EngineId = 8, GearboxId = 3, Price = 5400 },
                new EngineSupportsGearbox { Id = 9, ModelId = 4, EngineId = 9, GearboxId = 3, Price = 6700 },
                new EngineSupportsGearbox { Id = 10, ModelId = 5, EngineId = 10, GearboxId = 3 },
                new EngineSupportsGearbox { Id = 11, ModelId = 5, EngineId = 11, GearboxId = 3, Price = 3500 },
                new EngineSupportsGearbox { Id = 12, ModelId = 5, EngineId = 12, GearboxId = 3, Price = 17000 },
                new EngineSupportsGearbox { Id = 13, ModelId = 5, EngineId = 13, GearboxId = 3, Price = 7700 },
                new EngineSupportsGearbox { Id = 14, ModelId = 6, EngineId = 14, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 15, ModelId = 7, EngineId = 15, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 16, ModelId = 7, EngineId = 16, GearboxId = 1, Price = 23200 },
                new EngineSupportsGearbox { Id = 17, ModelId = 7, EngineId = 17, GearboxId = 1, Price = 25900 },
                new EngineSupportsGearbox { Id = 18, ModelId = 7, EngineId = 18, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 19, ModelId = 8, EngineId = 19, GearboxId = 2 },
                new EngineSupportsGearbox { Id = 20, ModelId = 8, EngineId = 20, GearboxId = 2, Price = 27300 },
                new EngineSupportsGearbox { Id = 21, ModelId = 9, EngineId = 21, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 22, ModelId = 9, EngineId = 22, GearboxId = 1, Price = 4300 },
                new EngineSupportsGearbox { Id = 23, ModelId = 9, EngineId = 23, GearboxId = 1, Price = 7600 },
                new EngineSupportsGearbox { Id = 24, ModelId = 9, EngineId = 24, GearboxId = 1, Price = 8900 },
                new EngineSupportsGearbox { Id = 25, ModelId = 9, EngineId = 25, GearboxId = 1, Price = 2700 },
                new EngineSupportsGearbox { Id = 26, ModelId = 9, EngineId = 26, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 27, ModelId = 10, EngineId = 27, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 28, ModelId = 10, EngineId = 28, GearboxId = 1, Price = 7500 },
                new EngineSupportsGearbox { Id = 29, ModelId = 10, EngineId = 29, GearboxId = 1, Price = 13200 },
                new EngineSupportsGearbox { Id = 30, ModelId = 10, EngineId = 30, GearboxId = 1, Price = 11100 },
                new EngineSupportsGearbox { Id = 31, ModelId = 10, EngineId = 31, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 32, ModelId = 11, EngineId = 32, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 33, ModelId = 11, EngineId = 33, GearboxId = 1, Price = 13700 },
                new EngineSupportsGearbox { Id = 34, ModelId = 11, EngineId = 34, GearboxId = 1, Price = 13900 },
                new EngineSupportsGearbox { Id = 35, ModelId = 12, EngineId = 35, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 36, ModelId = 12, EngineId = 36, GearboxId = 1, Price = 17300 },
                new EngineSupportsGearbox { Id = 37, ModelId = 13, EngineId = 37, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 38, ModelId = 14, EngineId = 38, GearboxId = 3 },
                new EngineSupportsGearbox { Id = 39, ModelId = 15, EngineId = 39, GearboxId = 3 },
                new EngineSupportsGearbox { Id = 40, ModelId = 16, EngineId = 40, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 41, ModelId = 16, EngineId = 41, GearboxId = 1, Price = 7500 },
                new EngineSupportsGearbox { Id = 42, ModelId = 16, EngineId = 42, GearboxId = 1, Price = 4300 },
                new EngineSupportsGearbox { Id = 43, ModelId = 16, EngineId = 43, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 44, ModelId = 17, EngineId = 44, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 45, ModelId = 17, EngineId = 45, GearboxId = 1, Price = 9900 },
                new EngineSupportsGearbox { Id = 46, ModelId = 17, EngineId = 46, GearboxId = 1, Price = 14870 },
                new EngineSupportsGearbox { Id = 47, ModelId = 17, EngineId = 47, GearboxId = 1, Price = 13530 },
                new EngineSupportsGearbox { Id = 48, ModelId = 17, EngineId = 48, GearboxId = 1, Price = 3000 },
                new EngineSupportsGearbox { Id = 49, ModelId = 18, EngineId = 49, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 50, ModelId = 18, EngineId = 50, GearboxId = 1, Price = 23000 },
                new EngineSupportsGearbox { Id = 51, ModelId = 18, EngineId = 51, GearboxId = 1, Price = 39500 },
                new EngineSupportsGearbox { Id = 52, ModelId = 18, EngineId = 52, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 53, ModelId = 19, EngineId = 53, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 54, ModelId = 19, EngineId = 54, GearboxId = 1, Price = 11300 },
                new EngineSupportsGearbox { Id = 55, ModelId = 20, EngineId = 55, GearboxId = 2 },
                new EngineSupportsGearbox { Id = 56, ModelId = 20, EngineId = 56, GearboxId = 4, Price = 22000 },
                new EngineSupportsGearbox { Id = 57, ModelId = 21, EngineId = 57, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 58, ModelId = 21, EngineId = 58, GearboxId = 1, Price = 9900 },
                new EngineSupportsGearbox { Id = 59, ModelId = 21, EngineId = 59, GearboxId = 1, Price = 29300 },
                new EngineSupportsGearbox { Id = 60, ModelId = 21, EngineId = 60, GearboxId = 1, Price = 13200 },
                new EngineSupportsGearbox { Id = 61, ModelId = 21, EngineId = 61, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 62, ModelId = 22, EngineId = 62, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 63, ModelId = 22, EngineId = 63, GearboxId = 1, Price = 6700 },
                new EngineSupportsGearbox { Id = 64, ModelId = 22, EngineId = 64, GearboxId = 1, Price = 9900 },
                new EngineSupportsGearbox { Id = 65, ModelId = 23, EngineId = 65, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 66, ModelId = 24, EngineId = 66, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 67, ModelId = 25, EngineId = 67, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 68, ModelId = 25, EngineId = 68, GearboxId = 1, Price = 39600 },
                new EngineSupportsGearbox { Id = 69, ModelId = 26, EngineId = 69, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 70, ModelId = 26, EngineId = 70, GearboxId = 1, Price = 17000 },
                new EngineSupportsGearbox { Id = 71, ModelId = 27, EngineId = 71, GearboxId = 1 },
                new EngineSupportsGearbox { Id = 72, ModelId = 27, EngineId = 71, GearboxId = 3, Price = 3400},
                new EngineSupportsGearbox { Id = 73, ModelId = 27, EngineId = 71, GearboxId = 4, Price = 6700},
                new EngineSupportsGearbox { Id = 74, ModelId = 27, EngineId = 72, GearboxId = 1, Price = 8800 },
                new EngineSupportsGearbox { Id = 75, ModelId = 27, EngineId = 72, GearboxId = 3, Price = 4500 },
                new EngineSupportsGearbox { Id = 76, ModelId = 27, EngineId = 72, GearboxId = 4, Price = 7000 },
                new EngineSupportsGearbox { Id = 77, ModelId = 27, EngineId = 73, GearboxId = 1, Price = 9900 },
                new EngineSupportsGearbox { Id = 78, ModelId = 27, EngineId = 73, GearboxId = 3, Price = 3200 },
                new EngineSupportsGearbox { Id = 79, ModelId = 27, EngineId = 73, GearboxId = 4, Price = 4000 },
                new EngineSupportsGearbox { Id = 80, ModelId = 28, EngineId = 74, GearboxId = 3 },
                new EngineSupportsGearbox { Id = 81, ModelId = 28, EngineId = 74, GearboxId = 4, Price = 5000 },
                new EngineSupportsGearbox { Id = 82, ModelId = 28, EngineId = 75, GearboxId = 3, Price = 5700 },
                new EngineSupportsGearbox { Id = 83, ModelId = 28, EngineId = 75, GearboxId = 4, Price = 5000 },
            };

            modelBuilder.Entity<EngineSupportsGearbox>().HasData(engineGearboxes);

            modelBuilder.HasSequence<int>("EnginesSupportGearboxes_Seq", schema: "public")
                .StartsAt(engineGearboxes.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<EngineSupportsGearbox>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"EnginesSupportGearboxes_Seq\"')");
        }
    }
}

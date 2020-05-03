using System.Linq;
using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class CarEngineTypeSeeds
    {
        public static void SeedCarEngineTypes(this ModelBuilder modelBuilder)
        {
            var carEngineTypes = new[]
            {
                new CarEngineType { Id = 1, Name = "Gasoline" },
                new CarEngineType { Id = 2, Name = "Diesel" },
                new CarEngineType { Id = 3, Name = "Electric" },
                new CarEngineType { Id = 4, Name = "Hybrid" }
            };

            modelBuilder.Entity<CarEngineType>().HasData(carEngineTypes);

            modelBuilder.HasSequence<int>("CarEngineTypes_Seq", schema: "public")
                .StartsAt(carEngineTypes.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<CarEngineType>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"CarEngineTypes_Seq\"')");
        }
    }
}

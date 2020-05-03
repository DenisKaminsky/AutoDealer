using System.Linq;
using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class CarEngineSeeds
    {
        public static void SeedCarEngines(this ModelBuilder modelBuilder)
        {
            var carEngines = new[]
            {
                new CarEngine { Id = 1, Name = "DB 11 I", TypeId = 1, Power = 510, Volume = 4.2f },
                new CarEngine { Id = 2, Name = "DB 11 II", TypeId = 1, Power = 510, Volume = 4.8f }
            };

            modelBuilder.Entity<CarEngine>().HasData(carEngines);

            modelBuilder.HasSequence<int>("CarEngines_Seq", schema: "public")
                .StartsAt(carEngines.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<CarEngine>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"CarEngines_Seq\"')");
        }
    }
}

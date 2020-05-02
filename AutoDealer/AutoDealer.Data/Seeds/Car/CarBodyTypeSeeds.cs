using System.Linq;
using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class CarBodyTypeSeeds
    {
        public static void SeedCarBodyTypes(this ModelBuilder modelBuilder)
        {
            var carBodyTypes = new[]
            {
               new CarBodyType { Id = 1, Name = "Sedan"},
               new CarBodyType { Id = 2, Name = "Hatchback"},
               new CarBodyType { Id = 3, Name = "Universal"},
               new CarBodyType { Id = 4, Name = "Coupe"},
               new CarBodyType { Id = 5, Name = "Pickup"},
               new CarBodyType { Id = 6, Name = "Minivan"},
               new CarBodyType { Id = 7, Name = "Cabriolet"},
               new CarBodyType { Id = 8, Name = "SUV"}
            };

            modelBuilder.Entity<CarBodyType>().HasData(carBodyTypes);

            modelBuilder.HasSequence<int>("CarBodyTypes_Seq", schema: "public")
                .StartsAt(carBodyTypes.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<CarBodyType>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"CarBodyTypes_Seq\"')");
        }
    }
}

using System.Linq;
using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class CarComplectationSeeds
    {
        public static void SeedCarComplectations(this ModelBuilder modelBuilder)
        {
            var carComplectations = new[]
            {
                new CarComplectation { Id = 1, Name = "Individual", ModelId = 1},
                new CarComplectation { Id = 2, Name = "Individual", ModelId = 2 },
                new CarComplectation { Id = 3, Name = "Individual", ModelId = 3 },
                new CarComplectation { Id = 4, Name = "Basis", ModelId = 4 },
                new CarComplectation { Id = 5, Name = "Design", ModelId = 4, Price = 5000 },
                new CarComplectation { Id = 6, Name = "Sport", ModelId = 4, Price = 10000 },
                new CarComplectation { Id = 7, Name = "Advance", ModelId = 4, Price = 11000 },
                new CarComplectation { Id = 8, Name = "Sport S", ModelId = 5 },
                new CarComplectation { Id = 9, Name = "Sport 40", ModelId = 5, Price = 5000 },
                new CarComplectation { Id = 10, Name = "Advance A", ModelId = 5, Price = 7000 },
                new CarComplectation { Id = 11, Name = "Advance S", ModelId = 6 },
                new CarComplectation { Id = 12, Name = "Advance X", ModelId = 6, Price = 12000 },
                new CarComplectation { Id = 13, Name = "Business", ModelId = 6, Price = 14000 },
                new CarComplectation { Id = 14, Name = "Individual", ModelId = 7 },
                new CarComplectation { Id = 15, Name = "Individual", ModelId = 8 },
                new CarComplectation { Id = 16, Name = "Urban", ModelId = 9 },
                new CarComplectation { Id = 17, Name = "Sport", ModelId = 9, Price = 10000 },
                new CarComplectation { Id = 18, Name = "Luxury", ModelId = 9, Price = 12000 },
                new CarComplectation { Id = 19, Name = "xLine", ModelId = 9, Price = 17000 },
                new CarComplectation { Id = 20, Name = "Business", ModelId = 10 },
                new CarComplectation { Id = 21, Name = "Business Plus", ModelId = 10, Price = 9000 },
                new CarComplectation { Id = 22, Name = "Sport Plus", ModelId = 10, Price = 8000 },
                new CarComplectation { Id = 23, Name = "Exclusive", ModelId = 10, Price = 14000 },
                new CarComplectation { Id = 24, Name = "Pure Excellence", ModelId = 11, },
                new CarComplectation { Id = 25, Name = "Sport Pure", ModelId = 11, Price = 7000 },
                new CarComplectation { Id = 26, Name = "Sport Pro", ModelId = 11, Price = 13000 },
                new CarComplectation { Id = 27, Name = "Special", ModelId = 11, Price = 20000 },
                new CarComplectation { Id = 28, Name = "Premium", ModelId = 12 },
                new CarComplectation { Id = 29, Name = "Platinum", ModelId = 12, Price = 20000 },
                new CarComplectation { Id = 30, Name = "Platinum", ModelId = 13 },
                new CarComplectation { Id = 31, Name = "Sport", ModelId = 13, Price = 15000 },
                new CarComplectation { Id = 32, Name = "Individual", ModelId = 14 },
                new CarComplectation { Id = 33, Name = "Individual", ModelId = 15 },
                new CarComplectation { Id = 34, Name = "Standard", ModelId = 16 },
                new CarComplectation { Id = 35, Name = "S", ModelId = 16, Price = 5000 },
                new CarComplectation { Id = 36, Name = "SE", ModelId = 16, Price = 9000 },
                new CarComplectation { Id = 37, Name = "R-Dynamic SE", ModelId = 16, Price = 12000 },
                new CarComplectation { Id = 38, Name = "Base", ModelId = 17},
                new CarComplectation { Id = 39, Name = "S", ModelId = 17, Price = 13000 },
                new CarComplectation { Id = 40, Name = "R-Dynamic HSE", ModelId = 17, Price = 20000 },
                new CarComplectation { Id = 41, Name = "Business", ModelId = 18},
                new CarComplectation { Id = 42, Name = "Luxury", ModelId = 18, Price = 20000 },
                new CarComplectation { Id = 43, Name = "Maybach", ModelId = 18, Price = 40000 },
                new CarComplectation { Id = 44, Name = "Business", ModelId = 19, },
                new CarComplectation { Id = 45, Name = "Premium", ModelId = 19, Price = 20000 },
                new CarComplectation { Id = 46, Name = "First Class", ModelId = 19, Price = 25000 },
                new CarComplectation { Id = 47, Name = "Sport", ModelId = 20 },
                new CarComplectation { Id = 48, Name = "Base", ModelId = 21 },
                new CarComplectation { Id = 49, Name = "S", ModelId = 21, Price = 13000 },
                new CarComplectation { Id = 50, Name = "Turbo", ModelId = 21, Price = 15000 },
                new CarComplectation { Id = 51, Name = "Macan", ModelId = 22 },
                new CarComplectation { Id = 52, Name = "S", ModelId = 22, Price = 10000 },
                new CarComplectation { Id = 53, Name = "Turbo", ModelId = 22, Price = 13000 },
                new CarComplectation { Id = 54, Name = "Individual", ModelId = 23 },
                new CarComplectation { Id = 55, Name = "Individual", ModelId = 24 },
                new CarComplectation { Id = 56, Name = "Model X", ModelId = 25 },
                new CarComplectation { Id = 57, Name = "Individual", ModelId = 26 },
                new CarComplectation { Id = 58, Name = "Trendline", ModelId = 27 },
                new CarComplectation { Id = 59, Name = "Comfortline", ModelId = 27, Price = 3000 },
                new CarComplectation { Id = 60, Name = "Conceptline", ModelId = 27, Price = 5000 },
                new CarComplectation { Id = 61, Name = "Allstar", ModelId = 27, Price = 6000 },
                new CarComplectation { Id = 62, Name = "Drive", ModelId = 27, Price = 7000 },
                new CarComplectation { Id = 63, Name = "Respect", ModelId = 28 },
                new CarComplectation { Id = 64, Name = "Business", ModelId = 28, Price = 3000 },
                new CarComplectation { Id = 65, Name = "Exclusive", ModelId = 28, Price = 5000 },
            };

            modelBuilder.Entity<CarComplectation>().HasData(carComplectations);

            modelBuilder.HasSequence<int>("CarComplectations_Seq", schema: "public")
                .StartsAt(carComplectations.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<CarComplectation>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"CarComplectations_Seq\"')");
        }
    }
}

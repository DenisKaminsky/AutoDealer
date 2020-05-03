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
                new CarEngine { Id = 1, Name = "DB 11", TypeId = 1, Power = 510, Volume = 4 },
                new CarEngine { Id = 2, Name = "DB 11", TypeId = 1, Power = 639, Volume = 5.2f },
                new CarEngine { Id = 3, Name = "V8 Vantage", TypeId = 1, Power = 510, Volume = 4 },
                new CarEngine { Id = 4, Name = "DBX", TypeId = 1, Power = 550, Volume = 4 },
                new CarEngine { Id = 5, Name = "A4", TypeId = 1, Power = 150, Volume = 1.4f },
                new CarEngine { Id = 6, Name = "A4", TypeId = 1, Power = 190, Volume = 2 },
                new CarEngine { Id = 7, Name = "A4", TypeId = 1, Power = 249, Volume = 2 },
                new CarEngine { Id = 8, Name = "A4", TypeId = 2, Power = 150, Volume = 2 },
                new CarEngine { Id = 9, Name = "A4", TypeId = 2, Power = 190, Volume = 2 },
                new CarEngine { Id = 10, Name = "A6", TypeId = 1, Power = 190, Volume = 2 },
                new CarEngine { Id = 11, Name = "A6", TypeId = 1, Power = 245, Volume = 2 },
                new CarEngine { Id = 12, Name = "A6", TypeId = 1, Power = 340, Volume = 3 },
                new CarEngine { Id = 13, Name = "A6", TypeId = 2, Power = 190, Volume = 2 },
                new CarEngine { Id = 14, Name = "Q7", TypeId = 2, Power = 249, Volume = 3 },
                new CarEngine { Id = 15, Name = "Bentayga", TypeId = 1, Power = 550, Volume = 4 },
                new CarEngine { Id = 16, Name = "Bentayga", TypeId = 1, Power = 608, Volume = 6 },
                new CarEngine { Id = 17, Name = "Bentayga", TypeId = 1, Power = 635, Volume = 6 },
                new CarEngine { Id = 18, Name = "Bentayga", TypeId = 2, Power = 435, Volume = 4 },
                new CarEngine { Id = 19, Name = "Continental GT", TypeId = 1, Power = 550, Volume = 4 },
                new CarEngine { Id = 20, Name = "Continental GT", TypeId = 1, Power = 635, Volume = 6 },
                new CarEngine { Id = 21, Name = "X3", TypeId = 1, Power = 184, Volume = 2 },
                new CarEngine { Id = 22, Name = "X3", TypeId = 1, Power = 249, Volume = 2 },
                new CarEngine { Id = 23, Name = "X3", TypeId = 1, Power = 360, Volume = 3 },
                new CarEngine { Id = 24, Name = "X3", TypeId = 2, Power = 190, Volume = 2 },
                new CarEngine { Id = 25, Name = "X3", TypeId = 2, Power = 249, Volume = 3 },
                new CarEngine { Id = 26, Name = "X3", TypeId = 2, Power = 326, Volume = 3 },
                new CarEngine { Id = 27, Name = "X5", TypeId = 1, Power = 340, Volume = 3 },
                new CarEngine { Id = 28, Name = "X5", TypeId = 1, Power = 530, Volume = 4.4f },
                new CarEngine { Id = 29, Name = "X5", TypeId = 2, Power = 231, Volume = 2 },
                new CarEngine { Id = 30, Name = "X5", TypeId = 2, Power = 249, Volume = 3 },
                new CarEngine { Id = 31, Name = "X5", TypeId = 2, Power = 400, Volume = 3 },
                new CarEngine { Id = 32, Name = "X7", TypeId = 1, Power = 340, Volume = 3 },
                new CarEngine { Id = 33, Name = "X7", TypeId = 2, Power = 249, Volume = 3 },
                new CarEngine { Id = 34, Name = "X7", TypeId = 2, Power = 400, Volume = 3 },
                new CarEngine { Id = 35, Name = "Escalade", TypeId = 1, Power = 409, Volume = 6.2f },
                new CarEngine { Id = 36, Name = "Escalade", TypeId = 1, Power = 426, Volume = 6.2f },
                new CarEngine { Id = 37, Name = "CT6", TypeId = 1, Power = 335, Volume = 3.7f },
                new CarEngine { Id = 38, Name = "488", TypeId = 1, Power = 720, Volume = 3.9f },
                new CarEngine { Id = 39, Name = "812", TypeId = 1, Power = 800, Volume = 6.5f },
                new CarEngine { Id = 40, Name = "Range Rover Evoque", TypeId = 1, Power = 200, Volume = 2 },
                new CarEngine { Id = 41, Name = "Range Rover Evoque", TypeId = 1, Power = 249, Volume = 2 },
                new CarEngine { Id = 42, Name = "Range Rover Evoque", TypeId = 2, Power = 150, Volume = 2 },
                new CarEngine { Id = 43, Name = "Range Rover Evoque", TypeId = 2, Power = 180, Volume = 2 },
                new CarEngine { Id = 44, Name = "Range Rover Velar", TypeId = 1, Power = 249, Volume = 2 },
                new CarEngine { Id = 45, Name = "Range Rover Velar", TypeId = 1, Power = 250, Volume = 2 },
                new CarEngine { Id = 46, Name = "Range Rover Velar", TypeId = 2, Power = 180, Volume = 2 },
                new CarEngine { Id = 47, Name = "Range Rover Velar", TypeId = 2, Power = 240, Volume = 2 },
                new CarEngine { Id = 48, Name = "Range Rover Velar", TypeId = 2, Power = 300, Volume = 3 },
                new CarEngine { Id = 49, Name = "S-Class", TypeId = 1, Power = 367, Volume = 3 },
                new CarEngine { Id = 50, Name = "S-Class", TypeId = 1, Power = 469, Volume = 4 },
                new CarEngine { Id = 51, Name = "S-Class", TypeId = 2, Power = 249, Volume = 2.9f },
                new CarEngine { Id = 52, Name = "S-Class", TypeId = 2, Power = 340, Volume = 2.9f },
                new CarEngine { Id = 53, Name = "GLS", TypeId = 1, Power = 367, Volume = 3 },
                new CarEngine { Id = 54, Name = "GLS", TypeId = 2, Power = 330, Volume = 2.9f },
                new CarEngine { Id = 55, Name = "SLS GT", TypeId = 1, Power = 571, Volume = 6.2f },
                new CarEngine { Id = 56, Name = "SLS GT", TypeId = 1, Power = 591, Volume = 6.2f },
                new CarEngine { Id = 57, Name = "Cayenne", TypeId = 1, Power = 340, Volume = 3 },
                new CarEngine { Id = 58, Name = "Cayenne", TypeId = 1, Power = 440, Volume = 2.9f },
                new CarEngine { Id = 59, Name = "Cayenne", TypeId = 1, Power = 550, Volume = 4 },
                new CarEngine { Id = 60, Name = "Cayenne", TypeId = 4, Power = 340, Volume = 3 },
                new CarEngine { Id = 61, Name = "Cayenne", TypeId = 4, Power = 550, Volume = 4 },
                new CarEngine { Id = 62, Name = "Macan", TypeId = 1, Power = 252, Volume = 2 },
                new CarEngine { Id = 63, Name = "Macan", TypeId = 1, Power = 354, Volume = 3 },
                new CarEngine { Id = 64, Name = "Macan", TypeId = 1, Power = 440, Volume = 2.9f },
                new CarEngine { Id = 65, Name = "Ghost", TypeId = 1, Power = 570, Volume = 6.6f },
                new CarEngine { Id = 66, Name = "Wraith", TypeId = 1, Power = 632, Volume = 6.6f },
                new CarEngine { Id = 67, Name = "Model X", TypeId = 3, Power = 714, Volume = 525 },
                new CarEngine { Id = 68, Name = "Model X", TypeId = 3, Power = 762, Volume = 560 },
                new CarEngine { Id = 69, Name = "Model S", TypeId = 3, Power = 449, Volume = 330 },
                new CarEngine { Id = 70, Name = "Model S", TypeId = 3, Power = 762, Volume = 568 },
                new CarEngine { Id = 71, Name = "Polo", TypeId = 1, Power = 90, Volume = 1.6f },
                new CarEngine { Id = 72, Name = "Polo", TypeId = 1, Power = 110, Volume = 1.6f },
                new CarEngine { Id = 73, Name = "Polo", TypeId = 1, Power = 125, Volume = 1.4f },
                new CarEngine { Id = 74, Name = "Passat", TypeId = 1, Power = 150, Volume = 1.4f },
                new CarEngine { Id = 75, Name = "Passat", TypeId = 1, Power = 190, Volume = 2 },
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

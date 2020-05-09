using System.Linq;
using AutoDealer.Data.Models.WorkOrder;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.WorkOrder
{
    public static class WorkSeeds
    {
        public static void SeedWorks(this ModelBuilder modelBuilder)
        {
            var works = new[]
            {
                new Work { Id = 1, Name = "Car painting", Price = 250 },
                new Work { Id = 2, Name = "Body polishing", Price = 200 },
                new Work { Id = 3, Name = "Spark plugs replacing", Price = 145 },
                new Work { Id = 4, Name = "Oil change", Price = 10 },
                new Work { Id = 5, Name = "Computer diagnostics", Price = 100 },
                new Work { Id = 6, Name = "Suspension diagnostics", Price = 150 },
                new Work { Id = 7, Name = "Engine diagnostics", Price = 230 },
                new Work { Id = 8, Name = "Gasket replacement", Price = 100 },
                new Work { Id = 9, Name = "Brake discs replacement", Price = 70 },
                new Work { Id = 10, Name = "Brake pads replacement", Price = 95 },
                new Work { Id = 11, Name = "Radiator replacement", Price = 135 },
                new Work { Id = 12, Name = "Coolant replacement", Price = 120 },
                new Work { Id = 13, Name = "Brake fluid replacement", Price = 90 },
                new Work { Id = 14, Name = "Power steering fluid replacement", Price = 115 },
                new Work { Id = 15, Name = "Gearbox repairment", Price = 200 },
                new Work { Id = 16, Name = "Electricians repairment", Price = 80 },
                new Work { Id = 17, Name = "Exhaust system repairment", Price = 30 },
                new Work { Id = 18, Name = "Tire fitting", Price = 40 },
                new Work { Id = 19, Name = "Car wash", Price = 10 },
                new Work { Id = 20, Name = "Dry cleaning", Price = 10 }
            };

            modelBuilder.Entity<Work>().HasData(works);

            modelBuilder.HasSequence<int>("Works_Seq", schema: "public")
                .StartsAt(works.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Work>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Works_Seq\"')");
        }
    }
}

using System.Linq;
using AutoDealer.Data.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class GearboxSeeds
    {
        public static void SeedGearboxes(this ModelBuilder modelBuilder)
        {
            var gearboxes = new[]
            {
                new Gearbox { Id = 1, Name = "Automatic" },
                new Gearbox { Id = 2, Name = "CVT" },
                new Gearbox { Id = 3, Name = "Robot" },
                new Gearbox { Id = 4, Name = "Manual" }
            };

            modelBuilder.Entity<Gearbox>().HasData(gearboxes);

            modelBuilder.HasSequence<int>("Gearboxes_Seq", schema: "public")
                .StartsAt(gearboxes.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Gearbox>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Gearboxes_Seq\"')");
        }
    }
}

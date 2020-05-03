using System.Linq;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Car.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car
{
    public static class CarModelBodyColorSeeds
    {
        public static void SeedCarModelBodyColors(this ModelBuilder modelBuilder)
        {
            var colors = new[]
            {
                new ModelSupportsColor {Id = 1, ColorCodeId = 1, Name = ""}
            };

            modelBuilder.Entity<ModelSupportsColor>().HasData(colors);

            modelBuilder.HasSequence<int>("CarModelBodyColor_Seq", schema: "public")
                .StartsAt(colors.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<ModelSupportsColor>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"CarModelBodyColor_Seq\"')");
        }
    }
}

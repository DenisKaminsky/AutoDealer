using System.Linq;
using AutoDealer.Data.Models.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Miscellaneous
{
    public static class ColorCodeSeeds
    {
        public static void SeedColorCodes(this ModelBuilder modelBuilder)
        {
            var colorCodes = new[]
            {
                new ColorCode {Id = 1, Name = "Black", HexValue = "000000"},
                new ColorCode {Id = 2, Name = "White", HexValue = "FFFFFF"},
                new ColorCode {Id = 3, Name = "Blue", HexValue = "0000CC"},
                new ColorCode {Id = 4, Name = "Red", HexValue = "CC0000"},
                new ColorCode {Id = 5, Name = "Green", HexValue = "00CC00"},
                new ColorCode {Id = 6, Name = "Gray", HexValue = "A0A0A0"},
                new ColorCode {Id = 7, Name = "Yellow", HexValue = "FFFF00"},
                new ColorCode {Id = 8, Name = "Brown", HexValue = "994C00"},
                new ColorCode {Id = 9, Name = "Purple", HexValue = "6600CC"}
            };

            modelBuilder.Entity<ColorCode>().HasData(colorCodes);

            modelBuilder.HasSequence<int>("ColorCodes_Seq", schema: "public")
                .StartsAt(colorCodes.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<ColorCode>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"ColorCodes_Seq\"')");
        }
    }
}

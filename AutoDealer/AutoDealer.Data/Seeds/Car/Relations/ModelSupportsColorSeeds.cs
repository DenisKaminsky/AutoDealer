using System.Linq;
using AutoDealer.Data.Models.Car.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car.Relations
{
    public static class ModelSupportsColorSeeds
    {
        public static void SeedModelsSupportColors(this ModelBuilder modelBuilder)
        {
            var modelsSupportColors = new[]
            {
                new ModelSupportsColor { Id = 1, ModelId = 1, ColorId = 3 },
                new ModelSupportsColor { Id = 2, ModelId = 1, ColorId = 2 },
                new ModelSupportsColor { Id = 3, ModelId = 1, ColorId = 8 },
                new ModelSupportsColor { Id = 4, ModelId = 2, ColorId = 1 },
                new ModelSupportsColor { Id = 5, ModelId = 2, ColorId = 2 },
                new ModelSupportsColor { Id = 6, ModelId = 2, ColorId = 4 },
                new ModelSupportsColor { Id = 7, ModelId = 2, ColorId = 6 },
                new ModelSupportsColor { Id = 8, ModelId = 3, ColorId = 1 },
                new ModelSupportsColor { Id = 9, ModelId = 3, ColorId = 4 },
                new ModelSupportsColor { Id = 10, ModelId = 4, ColorId = 1 },
                new ModelSupportsColor { Id = 11, ModelId = 4, ColorId = 2 },
                new ModelSupportsColor { Id = 12, ModelId = 4, ColorId = 4 },
                new ModelSupportsColor { Id = 13, ModelId = 4, ColorId = 5 },
                new ModelSupportsColor { Id = 14, ModelId = 5, ColorId = 1 },
                new ModelSupportsColor { Id = 15, ModelId = 5, ColorId = 6 },
                new ModelSupportsColor { Id = 16, ModelId = 5, ColorId = 3 },
                new ModelSupportsColor { Id = 17, ModelId = 5, ColorId = 2 },
                new ModelSupportsColor { Id = 18, ModelId = 6, ColorId = 1 },
                new ModelSupportsColor { Id = 19, ModelId = 6, ColorId = 2 },
                new ModelSupportsColor { Id = 20, ModelId = 6, ColorId = 8 },
                new ModelSupportsColor { Id = 21, ModelId = 6, ColorId = 3 },
                new ModelSupportsColor { Id = 22, ModelId = 7, ColorId = 1 },
                new ModelSupportsColor { Id = 23, ModelId = 7, ColorId = 2 },
                new ModelSupportsColor { Id = 24, ModelId = 7, ColorId = 5 },
                new ModelSupportsColor { Id = 25, ModelId = 7, ColorId = 9 },
                new ModelSupportsColor { Id = 26, ModelId = 7, ColorId = 3 },
                new ModelSupportsColor { Id = 27, ModelId = 8, ColorId = 1 },
                new ModelSupportsColor { Id = 28, ModelId = 8, ColorId = 2 },
                new ModelSupportsColor { Id = 29, ModelId = 8, ColorId = 5 },
                new ModelSupportsColor { Id = 30, ModelId = 8, ColorId = 9 },
                new ModelSupportsColor { Id = 31, ModelId = 8, ColorId = 3 },
                new ModelSupportsColor { Id = 32, ModelId = 9, ColorId = 1 },
                new ModelSupportsColor { Id = 33, ModelId = 9, ColorId = 2 },
                new ModelSupportsColor { Id = 34, ModelId = 9, ColorId = 6 },
                new ModelSupportsColor { Id = 35, ModelId = 9, ColorId = 3 },
                new ModelSupportsColor { Id = 36, ModelId = 10, ColorId = 1 },
                new ModelSupportsColor { Id = 37, ModelId = 10, ColorId = 2 },
                new ModelSupportsColor { Id = 38, ModelId = 10, ColorId = 6 },
                new ModelSupportsColor { Id = 39, ModelId = 10, ColorId = 3 },
                new ModelSupportsColor { Id = 40, ModelId = 11, ColorId = 1 },
                new ModelSupportsColor { Id = 41, ModelId = 11, ColorId = 2 },
                new ModelSupportsColor { Id = 42, ModelId = 11, ColorId = 6 },
                new ModelSupportsColor { Id = 43, ModelId = 11, ColorId = 3 },
                new ModelSupportsColor { Id = 44, ModelId = 12, ColorId = 1 },
                new ModelSupportsColor { Id = 45, ModelId = 12, ColorId = 2 },
                new ModelSupportsColor { Id = 46, ModelId = 12, ColorId = 4 },
                new ModelSupportsColor { Id = 47, ModelId = 12, ColorId = 8 },
                new ModelSupportsColor { Id = 48, ModelId = 13, ColorId = 1 },
                new ModelSupportsColor { Id = 49, ModelId = 13, ColorId = 2 },
                new ModelSupportsColor { Id = 50, ModelId = 13, ColorId = 4 },
                new ModelSupportsColor { Id = 51, ModelId = 13, ColorId = 8 },
                new ModelSupportsColor { Id = 52, ModelId = 14, ColorId = 2 },
                new ModelSupportsColor { Id = 53, ModelId = 14, ColorId = 4 },
                new ModelSupportsColor { Id = 54, ModelId = 14, ColorId = 7 },
                new ModelSupportsColor { Id = 55, ModelId = 15, ColorId = 1 },
                new ModelSupportsColor { Id = 56, ModelId = 15, ColorId = 6 },
                new ModelSupportsColor { Id = 57, ModelId = 16, ColorId = 1 },
                new ModelSupportsColor { Id = 58, ModelId = 16, ColorId = 2 },
                new ModelSupportsColor { Id = 59, ModelId = 16, ColorId = 5 },
                new ModelSupportsColor { Id = 60, ModelId = 16, ColorId = 3 },
                new ModelSupportsColor { Id = 61, ModelId = 17, ColorId = 1 },
                new ModelSupportsColor { Id = 62, ModelId = 17, ColorId = 2 },
                new ModelSupportsColor { Id = 63, ModelId = 17, ColorId = 5 },
                new ModelSupportsColor { Id = 64, ModelId = 17, ColorId = 3 },
                new ModelSupportsColor { Id = 65, ModelId = 18, ColorId = 1 },
                new ModelSupportsColor { Id = 66, ModelId = 18, ColorId = 2 },
                new ModelSupportsColor { Id = 67, ModelId = 18, ColorId = 4 },
                new ModelSupportsColor { Id = 68, ModelId = 18, ColorId = 5 },
                new ModelSupportsColor { Id = 69, ModelId = 19, ColorId = 1 },
                new ModelSupportsColor { Id = 70, ModelId = 19, ColorId = 2 },
                new ModelSupportsColor { Id = 71, ModelId = 19, ColorId = 8 },
                new ModelSupportsColor { Id = 72, ModelId = 19, ColorId = 3 },
                new ModelSupportsColor { Id = 73, ModelId = 20, ColorId = 1 },
                new ModelSupportsColor { Id = 74, ModelId = 20, ColorId = 2 },
                new ModelSupportsColor { Id = 75, ModelId = 21, ColorId = 2 },
                new ModelSupportsColor { Id = 76, ModelId = 21, ColorId = 3 },
                new ModelSupportsColor { Id = 77, ModelId = 21, ColorId = 8 },
                new ModelSupportsColor { Id = 78, ModelId = 21, ColorId = 1 },
                new ModelSupportsColor { Id = 79, ModelId = 22, ColorId = 1 },
                new ModelSupportsColor { Id = 80, ModelId = 22, ColorId = 2 },
                new ModelSupportsColor { Id = 81, ModelId = 22, ColorId = 4 },
                new ModelSupportsColor { Id = 82, ModelId = 22, ColorId = 3 },
                new ModelSupportsColor { Id = 83, ModelId = 22, ColorId = 5 },
                new ModelSupportsColor { Id = 84, ModelId = 23, ColorId = 2 },
                new ModelSupportsColor { Id = 85, ModelId = 23, ColorId = 4 },
                new ModelSupportsColor { Id = 86, ModelId = 24, ColorId = 3 },
                new ModelSupportsColor { Id = 87, ModelId = 24, ColorId = 5 },
                new ModelSupportsColor { Id = 88, ModelId = 25, ColorId = 2 },
                new ModelSupportsColor { Id = 89, ModelId = 25, ColorId = 3 },
                new ModelSupportsColor { Id = 90, ModelId = 26, ColorId = 2 },
                new ModelSupportsColor { Id = 91, ModelId = 26, ColorId = 4 },
                new ModelSupportsColor { Id = 92, ModelId = 27, ColorId = 1 },
                new ModelSupportsColor { Id = 93, ModelId = 27, ColorId = 2 },
                new ModelSupportsColor { Id = 94, ModelId = 27, ColorId = 6 },
                new ModelSupportsColor { Id = 95, ModelId = 28, ColorId = 1 },
                new ModelSupportsColor { Id = 96, ModelId = 28, ColorId = 2 },
                new ModelSupportsColor { Id = 97, ModelId = 28, ColorId = 6 },
                new ModelSupportsColor { Id = 98, ModelId = 28, ColorId = 3 },
                new ModelSupportsColor { Id = 99, ModelId = 28, ColorId = 4 },
            };

            modelBuilder.Entity<ModelSupportsColor>().HasData(modelsSupportColors);

            modelBuilder.HasSequence<int>("ModelsSupportColors_Seq", schema: "public")
                .StartsAt(modelsSupportColors.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<ModelSupportsColor>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"ModelsSupportColors_Seq\"')");
        }
    }
}

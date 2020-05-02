using System.Linq;
using AutoDealer.Data.Models.Car.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Car.Relations
{
    public static class ModelSupportsBodyTypeSeeds
    {
        public static void SeedModelSupportsBodyType(this ModelBuilder modelBuilder)
        {
            var modelBodyTypes = new[]
            {
                new ModelSupportsBodyType { Id = 1, ModelId = 1, BodyTypeId = 4},
                new ModelSupportsBodyType { Id = 2, ModelId = 1, BodyTypeId = 7, Price = 10000 },
                new ModelSupportsBodyType { Id = 3, ModelId = 2, BodyTypeId = 4},
                new ModelSupportsBodyType { Id = 4, ModelId = 3, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 5, ModelId = 4, BodyTypeId = 1},
                new ModelSupportsBodyType { Id = 6, ModelId = 5, BodyTypeId = 1},
                new ModelSupportsBodyType { Id = 7, ModelId = 6, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 8, ModelId = 7, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 9, ModelId = 8, BodyTypeId = 4},
                new ModelSupportsBodyType { Id = 10, ModelId = 9, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 11, ModelId = 10, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 12, ModelId = 11, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 13, ModelId = 12, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 14, ModelId = 13, BodyTypeId = 1},
                new ModelSupportsBodyType { Id = 15, ModelId = 14, BodyTypeId = 4},
                new ModelSupportsBodyType { Id = 16, ModelId = 14, BodyTypeId = 7, Price = 37000 },
                new ModelSupportsBodyType { Id = 18, ModelId = 15, BodyTypeId = 4},
                new ModelSupportsBodyType { Id = 19, ModelId = 16, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 20, ModelId = 17, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 22, ModelId = 18, BodyTypeId = 1, Price = 13800 },
                new ModelSupportsBodyType { Id = 23, ModelId = 18, BodyTypeId = 4},
                new ModelSupportsBodyType { Id = 24, ModelId = 19, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 25, ModelId = 20, BodyTypeId = 4, Price = 18500 },
                new ModelSupportsBodyType { Id = 26, ModelId = 20, BodyTypeId = 7},
                new ModelSupportsBodyType { Id = 27, ModelId = 21, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 28, ModelId = 22, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 29, ModelId = 23, BodyTypeId = 1},
                new ModelSupportsBodyType { Id = 30, ModelId = 24, BodyTypeId = 4},
                new ModelSupportsBodyType { Id = 31, ModelId = 25, BodyTypeId = 8},
                new ModelSupportsBodyType { Id = 32, ModelId = 26, BodyTypeId = 2},
                new ModelSupportsBodyType { Id = 33, ModelId = 27, BodyTypeId = 1},
                new ModelSupportsBodyType { Id = 34, ModelId = 28, BodyTypeId = 1},
            };

            modelBuilder.Entity<ModelSupportsBodyType>().HasData(modelBodyTypes);

            modelBuilder.HasSequence<int>("ModelBodyTypes_Seq", schema: "public")
                .StartsAt(modelBodyTypes.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<ModelSupportsBodyType>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"ModelBodyTypes_Seq\"')");
        }
    }
}

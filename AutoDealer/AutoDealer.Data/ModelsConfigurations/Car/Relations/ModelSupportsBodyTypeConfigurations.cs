using AutoDealer.Data.Models.Car.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car.Relations
{
    public static class ModelSupportsBodyTypeConfigurations
    {
        public static void ConfigureModelSupportsBodyType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelSupportsBodyType>()
                .HasIndex(x => new { x.ModelId, x.BodyTypeId })
                .IsUnique();

            modelBuilder.Entity<ModelSupportsBodyType>()
                .HasOne(x => x.BodyType)
                .WithMany(x => x.SupportedModels)
                .HasForeignKey(x => x.BodyTypeId);

            modelBuilder.Entity<ModelSupportsBodyType>()
                .HasOne(x => x.Model)
                .WithMany(x => x.SupportedBodyTypes)
                .HasForeignKey(x => x.ModelId);

            modelBuilder.Entity<ModelSupportsBodyType>()
                .HasCheckConstraint("CK_ModelsSupportBodyTypes_Price", $"\"{nameof(ModelSupportsBodyType.Price)}\" >= 0");
        }
    }
}

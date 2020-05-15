using AutoDealer.Data.Models.Car.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car.Relations
{
    public static class ModelSupportsColorConfigurations
    {
        public static void ConfigureModelSupportsColor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelSupportsColor>()
                .HasIndex(x => new { x.ModelId, x.ColorId })
                .IsUnique();

            modelBuilder.Entity<ModelSupportsColor>()
                .HasOne(x => x.Color)
                .WithMany(x => x.SupportedModels)
                .HasForeignKey(x => x.ColorId);

            modelBuilder.Entity<ModelSupportsColor>()
                .HasOne(x => x.Model)
                .WithMany(x => x.SupportedColors)
                .HasForeignKey(x => x.ModelId);
        }
    }
}

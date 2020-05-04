using AutoDealer.Data.Models.Car.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car.Relations
{
    public static class EngineSupportsGearboxConfigurations
    {
        public static void ConfigureEngineSupportsGearbox(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngineSupportsGearbox>()
                .HasOne(x => x.Model)
                .WithMany(x => x.SupportedEngineGearboxes)
                .HasForeignKey(x => x.ModelId);

            modelBuilder.Entity<EngineSupportsGearbox>()
                .HasOne(x => x.Engine)
                .WithMany(x => x.SupportedGearboxes)
                .HasForeignKey(x => x.EngineId);

            modelBuilder.Entity<EngineSupportsGearbox>()
                .HasOne(x => x.Gearbox)
                .WithMany(x => x.SupportedEngines)
                .HasForeignKey(x => x.GearboxId);

            modelBuilder.Entity<EngineSupportsGearbox>()
                .HasCheckConstraint("CK_EnginesSupportGearboxes_Price", $"\"{nameof(EngineSupportsGearbox.Price)}\" >= 0");
        }
    }
}

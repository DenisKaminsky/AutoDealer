using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Constraints.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Car
{
    public static class CarPhotoConfigurations
    {
        public static void ConfigureCarPhoto(this ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<CarPhoto>()
                .HasIndex(x => x.FileName)
                .IsUnique();

            modelBuilder.Entity<CarPhoto>()
                .Property(x => x.FileName)
                .HasMaxLength(CarPhotoConstraints.FileNameMaxLength)
                .IsRequired();
        }
    }
}

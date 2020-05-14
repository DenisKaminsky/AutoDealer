using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Constraints.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Miscellaneous
{
    public static class SupplierPhotoConfigurations
    {
        public static void ConfigureSupplierPhoto(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierPhoto>()
                .HasIndex(x => x.FileName)
                .IsUnique();

            modelBuilder.Entity<SupplierPhoto>()
                .Property(x => x.FileName)
                .HasMaxLength(SupplierPhotoConstraints.FileNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<SupplierPhoto>()
                .HasCheckConstraint("CK_SupplierPhoto_FileSize", $"\"{nameof(SupplierPhoto.FileSize)}\" > 0");
        }
    }
}

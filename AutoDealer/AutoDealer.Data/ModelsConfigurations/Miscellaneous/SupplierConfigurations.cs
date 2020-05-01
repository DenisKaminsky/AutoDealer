using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Constraints.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Miscellaneous
{
    public static class SupplierConfigurations
    {
        public static void ConfigureSupplier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasIndex(x => x.Ein)
                .IsUnique();

            modelBuilder.Entity<Supplier>()
                .Property(x => x.CompanyName)
                .HasMaxLength(SupplierConstraints.CompanyNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Supplier>()
                .Property(x => x.Ein)
                .HasMaxLength(SupplierConstraints.EinMaxLength)
                .IsRequired();

            modelBuilder.Entity<Supplier>()
                .Property(x => x.Phone)
                .HasMaxLength(SupplierConstraints.PhoneMaxLength)
                .IsRequired();

            modelBuilder.Entity<Supplier>()
                .Property(x => x.Email)
                .HasMaxLength(SupplierConstraints.EmailMaxLength)
                .IsRequired();

            modelBuilder.Entity<Supplier>()
                .Property(x => x.Address)
                .HasMaxLength(SupplierConstraints.AddressMaxLength)
                .IsRequired();
        }
    }
}

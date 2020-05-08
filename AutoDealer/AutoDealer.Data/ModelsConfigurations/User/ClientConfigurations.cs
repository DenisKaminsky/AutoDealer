using AutoDealer.Data.Models.User;
using AutoDealer.Miscellaneous.Constraints.User;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.User
{
    public static class ClientConfigurations
    {
        public static void ConfigureClient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasIndex(x => x.PassportId)
                .IsUnique();

            modelBuilder.Entity<Client>()
                .Property(x => x.FirstName)
                .HasMaxLength(ClientConstraints.FirstNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(x => x.LastName)
                .HasMaxLength(ClientConstraints.LastNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(x => x.Email)
                .HasMaxLength(ClientConstraints.EmailMaxLength);

            modelBuilder.Entity<Client>()
                .Property(x => x.PassportId)
                .HasMaxLength(ClientConstraints.PassportIdMaxLength)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(x => x.Phone)
                .HasMaxLength(ClientConstraints.PhoneMaxLength)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(x => x.Address)
                .HasMaxLength(ClientConstraints.AddressMaxLength)
                .IsRequired();
        }
    }
}

using AutoDealer.Data.Models.User;
using AutoDealer.Miscellaneous.Constraints.User;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.User
{
    public static class UserRoleConfigurations
    {
        public static void ConfigureUserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .Property(x => x.Name)
                .HasMaxLength(UserRoleConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}

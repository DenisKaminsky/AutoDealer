using AutoDealer.Data.Extensions;
using AutoDealer.Data.Models.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data
{
    public class DataContext : DbContext
    {

        #region Miscellaneous
        public DbSet<Country> Countries { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        #endregion

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureModels();
            builder.Seed();
        }
    }
}

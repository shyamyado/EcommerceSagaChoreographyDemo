using Catalog.API.Infrastructure.EntityConfiguration;
using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class CatalogDBContext : DbContext
    {
        private const string ConnectionString = "Server=SHYAMASUS\\SQLEXPRESS;Initial Catalog=ECommerceCatalog;Integrated Security=true;TrustServerCertificate=True;";

        public CatalogDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<CatalogProduct> CatalogProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CatalogEntityTypeConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

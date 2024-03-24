using Microsoft.EntityFrameworkCore;
using Stock.API.Infrastucture.EntityConfiguration;
using Stock.API.Model;

namespace Stock.API.Infrastucture
{
    public class StockDBContext : DbContext
    {
        private const string ConnectionString = "Server=SHYAMASUS\\SQLEXPRESS;Initial Catalog=ECommerceStock;Integrated Security=true;TrustServerCertificate=True;";

        public StockDBContext(DbContextOptions dbContextOptions): base(dbContextOptions) { }

        public DbSet<ProductStock> ProductStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductStockEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, p => p.MigrationsAssembly("Stock.API"));
        }

    }
}

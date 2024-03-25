using Microsoft.EntityFrameworkCore;
using Order.API.Infrastructure.EntityConfiguration;
using Order.API.Model;

namespace Order.API.Infrastructure
{
    public class OrderDBContext : DbContext
    {
        private const string ConnectionString = "Server=SHYAMASUS\\SQLEXPRESS;Initial Catalog=ECommerceOrder;Integrated Security=true;TrustServerCertificate=True;";

        public OrderDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<ProductOrder> ProductOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, p => p.MigrationsAssembly("Order.API"));
        }
    }
}

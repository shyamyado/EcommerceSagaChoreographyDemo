using Microsoft.EntityFrameworkCore;
using Payment.API.Infrastructure.EntityConfiguration;
using Payment.API.Models;

namespace Payment.API.Infrastructure
{
    public class PaymentDBContext : DbContext
    {

        private const string ConnectionString = "Server=SHYAMASUS\\SQLEXPRESS;Initial Catalog=ECommercePayment;Integrated Security=true;TrustServerCertificate=True;";

        public PaymentDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }


        public DbSet<PaymentOrder> PaymentOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, p => p.MigrationsAssembly("Payment.API"));
        }
    }
}

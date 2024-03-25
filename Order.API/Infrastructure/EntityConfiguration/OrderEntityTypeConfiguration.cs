using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.API.Model;

namespace Order.API.Infrastructure.EntityConfiguration
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(t => t.OrderId).IsClustered();
            builder.Property(t => t.CustomerId);
            builder.Property(t => t.OrderStatus);
            builder.Property(t => t.CreatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(t => t.UpdatedDate).HasDefaultValue(DateTime.UtcNow);
        }
    }
}

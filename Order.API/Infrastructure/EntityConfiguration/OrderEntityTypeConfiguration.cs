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
            builder.HasKey(t => t.Id).IsClustered();
            builder.HasKey(t => t.OrderId);
            builder.Property(t => t.CustomerId);
            builder.Property(t => t.OrderStatus);
            builder.Property(t => t.ProductId);
            builder.Property(t => t.Quantity);
            builder.Property(t => t.CreatedDate).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);
            builder.Property(t => t.UpdatedDate).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);
        }
    }
}

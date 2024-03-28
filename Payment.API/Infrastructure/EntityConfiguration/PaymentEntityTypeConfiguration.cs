using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.API.Models;

namespace Payment.API.Infrastructure.EntityConfiguration
{
    public class PaymentEntityTypeConfiguration : IEntityTypeConfiguration<PaymentOrder>
    {

        public void Configure(EntityTypeBuilder<PaymentOrder> builder)
        {
            builder.ToTable("PaymentOder");
            builder.HasKey(x=>x.PaymentId).IsClustered();
            builder.Property(x => x.OrderId);
            builder.Property(x => x.Amount).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.PaymentStatus);
            builder.Property(x => x.PaymentDate).HasColumnType("datetime");
        }
    }
}

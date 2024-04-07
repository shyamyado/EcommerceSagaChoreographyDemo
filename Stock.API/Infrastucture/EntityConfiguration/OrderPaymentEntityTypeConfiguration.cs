using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.API.Model;

namespace Stock.API.Infrastucture.EntityConfiguration
{
    public class OrderPaymentEntityTypeConfiguration : IEntityTypeConfiguration<OrderPayment>
    {
        public void Configure(EntityTypeBuilder<OrderPayment> builder)
        {
            builder.ToTable("OrderPayment");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.OrderId).IsRequired();
            builder.Property(x=>x.PaymentStatus);
            builder.Property(x => x.Amount);

        }
    }
}

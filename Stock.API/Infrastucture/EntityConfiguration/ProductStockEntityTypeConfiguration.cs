using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.API.Model;

namespace Stock.API.Infrastucture.EntityConfiguration
{
    public class ProductStockEntityTypeConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.ToTable("ProductStock");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Quantity).HasDefaultValue(0);
        }
    }
}


using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.EntityConfiguration
{
    public class CatalogEntityTypeConfiguration : IEntityTypeConfiguration<CatalogProduct>
    {
        public void Configure(EntityTypeBuilder<CatalogProduct> builder)
        {
            builder.ToTable("Catalog");
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductName);
        }
    }
}

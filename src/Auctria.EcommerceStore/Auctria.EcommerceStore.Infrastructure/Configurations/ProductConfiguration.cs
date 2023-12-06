using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auctria.EcommerceStore.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(t => t.SKU)
            .HasMaxLength(200)
            .IsRequired();
        builder.HasIndex(p => p.SKU).IsUnique();

        //builder.Property(p => p.RowVersion)
        //    .IsRowVersion();
    }
}

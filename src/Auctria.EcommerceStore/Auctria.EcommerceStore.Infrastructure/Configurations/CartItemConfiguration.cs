using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auctria.EcommerceStore.Infrastructure.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.Property(t => t.ProductId)
            .IsRequired();

        builder.Property(t => t.Quantity)
            .IsRequired();

        //builder.Property(p => p.RowVersion)
        //    .IsRowVersion();
    }
}

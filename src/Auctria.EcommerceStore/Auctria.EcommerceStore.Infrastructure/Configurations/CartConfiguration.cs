using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auctria.EcommerceStore.Infrastructure.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(t => t.CustomerId)
            .IsRequired();

        //builder.Property(p => p.RowVersion)
        //    .IsRowVersion();
    }
}

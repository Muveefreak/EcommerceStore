namespace Auctria.EcommerceStore.Core.Domain.Entities
{
    public class Cart : BaseAuditableEntity
    {
        public int CustomerId { get; set; }
        public List<CartItem> CartItems { get; set; }

        // RowVersion property for row concurrency
        // public byte[] RowVersion { get; set; }
    }
}

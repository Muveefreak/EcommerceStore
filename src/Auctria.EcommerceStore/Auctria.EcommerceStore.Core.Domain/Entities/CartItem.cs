namespace Auctria.EcommerceStore.Core.Domain.Entities
{
    public class CartItem : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        
        // RowVersion property for row concurrency
        // public byte[] RowVersion { get; set; }
    }
}

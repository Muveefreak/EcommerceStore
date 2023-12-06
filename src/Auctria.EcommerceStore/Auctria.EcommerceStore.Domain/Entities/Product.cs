namespace Auctria.EcommerceStore.Core.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public string SKU { get; set; }
        public int Stock { get; set; }

        // RowVersion property for row concurrency
        // public byte[] RowVersion { get; set; }
    }
}

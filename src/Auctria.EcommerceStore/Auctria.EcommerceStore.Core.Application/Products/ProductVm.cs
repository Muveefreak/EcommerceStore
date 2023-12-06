namespace Auctria.EcommerceStore.Core.Application.Products;

public class ProductVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float UnitPrice { get; set; }
    public string SKU { get; set; }
    public int Stock { get; set; }
}

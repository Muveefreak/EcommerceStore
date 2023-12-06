namespace Auctria.EcommerceStore.Core.Application.CartItems;

public class CartItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public float UnitPrice { get; set; }
    public Product Product { get; set; }
}

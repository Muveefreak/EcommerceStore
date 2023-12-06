namespace Auctria.EcommerceStore.Core.Application.Carts;

public class CartVm
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int TotalQuantity { get; set; }
    public float TotalPrice { get; set; }
    public List<CartItemDto> CartItems { get; set; }

    internal int SetTotalQuantity()
    {
        return CartItems?.Sum(x => x.Quantity) ?? 0;
    }
    internal float SetTotalPrice()
    {
        return CartItems?.Sum(item => item.Quantity * item.Product.UnitPrice) ?? 0f;
    }
}

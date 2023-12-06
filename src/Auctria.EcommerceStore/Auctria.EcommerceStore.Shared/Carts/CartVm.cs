namespace Auctria.EcommerceStore.Core.Application.Carts;

public class CartVm
{
    private int _totalQuantity;
    private float _totalPrice;
    public string CustomerId { get; set; }
    public float TotalPrice
    {
        get { return _totalPrice; }
        internal set
        {
            _totalPrice = SetTotalPrice();
        }
    }
    public int TotalQuantity
    {
        get { return _totalQuantity; }
        internal set
        {
            _totalQuantity = SetTotalQuantity();
        }
    }
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



namespace Auctria.EcommerceStore.Core.Application.Common.Extensions;

public static class CartExtensions
{
    public static CartVm ToVm(this Cart cart)
    {
        if (cart == null)
        {
            return null;
        }

        var cartVm = new CartVm
        {
            Id = cart.Id,
            CustomerId = cart.CustomerId,
            CartItems = new List<CartItemDto>()
        };

        if (cart.CartItems != null)
        {
            foreach (var cartItem in cart.CartItems)
            {
                var cartItemVm = new CartItemDto
                {
                    Id = cartItem.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Product = cartItem.Product,
                };

                cartVm.CartItems.Add(cartItemVm);
            }
        }

        cartVm.TotalQuantity = cartVm.SetTotalQuantity();
        cartVm.TotalPrice = cartVm.SetTotalPrice();

        return cartVm;
    }
}

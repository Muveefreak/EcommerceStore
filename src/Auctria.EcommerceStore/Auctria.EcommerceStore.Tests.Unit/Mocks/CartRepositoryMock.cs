using Microsoft.EntityFrameworkCore;
using Moq;

namespace Auctria.EcommerceStore.Tests.Unit.Mocks;

public class CartRepositoryMock
{
    public static Mock<ICartRepository> GetCartRepository()
    {
        int cartId = 1;

        var product1 = new Product
        {
            Id = 1,
            Name = "Coke",
            UnitPrice = 10,
            SKU = "CKE",
            Stock = 5,
            Description = "Drink"
        };

        var product2 = new Product
        {
            Id = 1,
            Name = "Coke",
            UnitPrice = 10,
            SKU = "CKE",
            Stock = 5,
            Description = "Drink"
        };

        var cartItems = new List<CartItem>
        {
            new CartItem
            {
                Id = 1,
                CartId = cartId,
                ProductId = product1.Id,
                Quantity = 3,
                //UnitPrice = 10,
                Product = product1
            },
            new CartItem
            {
                Id = 2,
                CartId = cartId,
                ProductId = product2.Id,
                Quantity = 4,
                //UnitPrice = 10,
                Product = product2
            }
        };
        var cart = new Cart
        {
            Id = cartId,
            CustomerId = 1,
            CartItems = cartItems
        };
        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(r => r.GetCartById(cartId)).ReturnsAsync(cart);
        return mockCartRepository;
    }
}

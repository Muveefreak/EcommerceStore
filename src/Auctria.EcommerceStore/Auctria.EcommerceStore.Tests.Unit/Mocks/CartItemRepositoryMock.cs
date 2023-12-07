using Moq;

namespace Auctria.EcommerceStore.Tests.Unit.Mocks
{
    public class CartItemRepositoryMock
    {
        public static Mock<ICartItemRepository> GetCartItemRepository()
        {
            var cartId = 1;

            var product = new Product
            {
                Id = 1,
                Name = "Coke",
                UnitPrice = 10,
                SKU = "CKE",
                Stock = 5,
                Description = "Drink"
            };

            var cartItems = new CartItem
            {
                Id = 1,
                CartId = cartId,
                ProductId = product.Id,
                Quantity = 3,
                Product = product
            };
            var mockCartItemRepository = new Mock<ICartItemRepository>();
            mockCartItemRepository.Setup(r => r.GetCartItemByProductIdAndCartId(product.Id, cartId)).ReturnsAsync(cartItems);
            return mockCartItemRepository;
        }
    }
}

using Moq;
using Shouldly;
using Xunit;

namespace Auctria.EcommerceStore.Tests.Unit.Application.Commands;

public class UpdateCartItemTest
{
    private readonly Mock<ICartItemRepository> _mockCartItemRepository;
    private readonly Mock<IProductRepository> _mockProductRepository;
    public UpdateCartItemTest()
    {
        _mockCartItemRepository = CartItemRepositoryMock.GetCartItemRepository();
        _mockProductRepository = ProductRepositoryMock.GetProducyRepository();
    }

    [Fact]
    public async Task Handle_Should_ReturnsTrue_OnSuccess_UpdateCartItem()
    {
        // Arrange
        var handler = new UpdateCartItemCommandHandler(_mockCartItemRepository.Object, _mockProductRepository.Object);

        // Act
        var result = await handler.Handle(new UpdateCartItemCommand{ CartId = 1, ProductId = 1, Quantity = 2 }, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<bool>();
        Assert.True(result);
    }
}

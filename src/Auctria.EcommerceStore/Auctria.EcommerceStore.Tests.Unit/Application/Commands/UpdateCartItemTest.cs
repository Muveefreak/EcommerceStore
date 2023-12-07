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
    public async Task UpdateCartItem_ReturnsTrue_Onsuccess()
    {
        // Arrange
        var handler = new UpdateCartItemCommandHandler(_mockCartItemRepository.Object, _mockProductRepository.Object);

        // Act
        var result = await handler.Handle(new UpdateCartItemCommand(), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<bool>();
        Assert.True(result);
    }
}

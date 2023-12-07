using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Xunit;

namespace Auctria.EcommerceStore.Tests.Unit.Application.Queries
{
    public class GetCartByIdTest
    {
        private readonly Mock<ICartRepository> _mockCartRepository;
        public GetCartByIdTest()
        {
            _mockCartRepository = CartRepositoryMock.GetCartRepository();
        }

        [Fact]
        public async Task GetCartById_ReturnsCorrectCart()
        {
            // Arrange
            var handler = new GetCartByIdQueryHandler(_mockCartRepository.Object);

            // Act
            var result = await handler.Handle(new GetCartByIdQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CartVm>();
            Assert.NotNull(result);
        }
    }
}

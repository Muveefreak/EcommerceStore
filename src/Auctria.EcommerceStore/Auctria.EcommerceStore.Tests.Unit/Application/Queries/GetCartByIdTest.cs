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
        public async Task Handle_Should_ReturnCart_OnSuccess_GetCartById()
        {
            // Arrange
            var handler = new GetCartByIdQueryHandler(_mockCartRepository.Object);

            // Act
            var result = await handler.Handle(new GetCartByIdQuery { Id = 1}, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CartVm>();
            Assert.NotNull(result);
        }
    }
}

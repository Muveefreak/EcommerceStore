namespace Auctria.EcommerceStore.Core.Application.Common.Persistence;
public interface ICartItemRepository : IRepository<CartItem>
{
    Task<CartItem?> GetCartItemByProductIdAndCartId(int productId, int cartId);
}

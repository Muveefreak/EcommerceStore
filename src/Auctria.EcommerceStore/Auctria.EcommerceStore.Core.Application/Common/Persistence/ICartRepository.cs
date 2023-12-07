namespace Auctria.EcommerceStore.Core.Application.Common.Persistence;
public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetCartById(int cartId);
}

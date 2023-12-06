using Microsoft.EntityFrameworkCore;

namespace Auctria.EcommerceStore.Infrastructure.Persistence.Repository;
public class CartItemRepository : Repository<CartItem, EcommerceStoreDbContext>, ICartItemRepository
{
    public CartItemRepository(EcommerceStoreDbContext dataContext) : base(dataContext)
    {
    }
    public Task<CartItem> FindById(int CartItemId)
    {
        return DbSet.FirstOrDefaultAsync(_ => _.Id == CartItemId);
    }

    public virtual async Task<CartItem> FindByProductIdAndCartId(int productId, int cartId)
    {
        if (productId < 1 || cartId < 1)
        {
            return null;
        }

        return DbSet.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);
    }
}

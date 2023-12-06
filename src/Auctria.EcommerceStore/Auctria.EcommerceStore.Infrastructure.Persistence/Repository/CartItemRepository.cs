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
}

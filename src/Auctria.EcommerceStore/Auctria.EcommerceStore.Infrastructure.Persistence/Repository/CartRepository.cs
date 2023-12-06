using Microsoft.EntityFrameworkCore;

namespace Auctria.EcommerceStore.Infrastructure.Persistence.Repository;
public class CartRepository : Repository<Cart, EcommerceStoreDbContext>, ICartRepository
{
    public CartRepository(EcommerceStoreDbContext dataContext) : base(dataContext)
    {
    }
    public Task<Cart> FindById(int CartId)
    {
        return DbSet
            .Include(_ => _.CartItems)
            .ThenInclude(c => c.Product)
            .FirstOrDefaultAsync(_ => _.Id == CartId);
    }
}

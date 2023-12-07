using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Auctria.EcommerceStore.Infrastructure.Persistence.Repository;
public class ProductRepository : Repository<Product, EcommerceStoreDbContext>, IProductRepository
{
    private readonly IMapper _mapper;
    public ProductRepository(EcommerceStoreDbContext dataContext,
        IMapper mapper) : base(dataContext)
    {
        _mapper = mapper;
    }
    public Task<Product?> GetProductById(int productId)
    {
        return DbSet.FirstOrDefaultAsync(_ => _.Id == productId);
    }

    public Task<PaginatedList<ProductVm>> GetAllProductsPaginatedList(int pageNumber, int pageSize)
    {
        return DbSet
            .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(pageNumber, pageSize);
    }
}

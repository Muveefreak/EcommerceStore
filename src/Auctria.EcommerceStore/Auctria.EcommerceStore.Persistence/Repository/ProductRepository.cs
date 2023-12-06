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
    public Task<Product> FindById(int productId)
    {
        return DbSet.FirstOrDefaultAsync(_ => _.Id == productId);
    }

    public Task<Product> FindBySKU(string sku)
    {
        return DbSet.FirstOrDefaultAsync(_ => _.SKU == sku);
    }

    public Task<PaginatedList<ProductVm>> GetAllPaginatedList(int pageNumber, int pageSize)
    {
        return DbSet
            .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(pageNumber, pageSize);
    }
}

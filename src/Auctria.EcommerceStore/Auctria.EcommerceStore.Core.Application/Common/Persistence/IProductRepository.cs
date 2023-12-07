namespace Auctria.EcommerceStore.Core.Application.Common.Persistence;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetProductById(int productId);
    Task<PaginatedList<ProductVm>> GetAllProductsPaginatedList(int pageNumber, int pageSize);
}

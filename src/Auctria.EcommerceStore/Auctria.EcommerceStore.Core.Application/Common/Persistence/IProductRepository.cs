
using Auctria.EcommerceStore.Core.Application.Carts.Query;
using Auctria.EcommerceStore.Core.Application.Common.Models;
using Auctria.EcommerceStore.Core.Application.Products;

namespace Auctria.EcommerceStore.Core.Application.Common.Persistence;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> FindById(int productId);
    Task<Product> FindBySKU(string sku);
    Task<PaginatedList<ProductVm>> GetAllPaginatedList(int pageNumber, int pageSize);
}

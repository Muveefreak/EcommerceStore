using Auctria.EcommerceStore.Core.Application.Products;

namespace Auctria.EcommerceStore.Core.Application.Common.Extensions
{
    public static class ProductExtensions
    {
        public static ProductVm ToVm(this Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductVm
            {
                Id = product.Id,
                Name = product.Name,
                UnitPrice = product.UnitPrice,
                Description = product.Description,
                SKU = product.SKU,
                Stock = product.Stock,
            };
        }
    }
}

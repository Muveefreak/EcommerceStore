using AutoMapper;
using Moq;

namespace Auctria.EcommerceStore.Tests.Unit.Mocks
{
    public class ProductRepositoryMock
    {
        private static readonly IMapper _mapper;

        static ProductRepositoryMock()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
        public static Mock<IProductRepository> GetProducyRepository()
        {
            int productId = 1;
            int pageNumber = 1;
            int pageSize = 10;

            var product = new Product
            {
                Id = productId,
                Name = "Coke",
                UnitPrice = 10,
                SKU = "CKE",
                Stock = 5,
                Description = "Drink"
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = productId,
                    Name = "Coke",
                    UnitPrice = 10,
                    SKU = "CKE",
                    Stock = 5,
                    Description = "Drink"
                },
                new Product
                {
                    Id = productId,
                    Name = "Coke",
                    UnitPrice = 10,
                    SKU = "CKE",
                    Stock = 5,
                    Description = "Drink"
                }
            }.AsQueryable();

            var paginatedList = new PaginatedList<ProductVm>(products.Select(p => _mapper.Map<ProductVm>(p)).ToList(), products.Count(), pageNumber, pageSize);


            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(r => r.GetProductById(productId)).ReturnsAsync(product);
            mockProductRepository.Setup(r => r.GetAllProductsPaginatedList(pageNumber, pageSize)).ReturnsAsync(paginatedList);
            return mockProductRepository;
        }
    }
}

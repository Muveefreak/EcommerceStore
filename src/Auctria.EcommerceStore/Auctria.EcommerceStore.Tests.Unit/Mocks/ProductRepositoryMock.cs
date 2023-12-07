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
            int pageNumber = 1;
            int pageSize = 10;

            var product1 = new Product
            {
                Id = 1,
                Name = "Coke",
                UnitPrice = 10,
                SKU = "CKE",
                Stock = 5,
                Description = "Drink"
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "Fanta",
                UnitPrice = 10,
                SKU = "FTA",
                Stock = 5,
                Description = "Drink"
            };

            var products = new List<Product>
            {
                product1,
                product2
            }.AsQueryable();

            var paginatedList = new PaginatedList<ProductVm>(products.Select(p => _mapper.Map<ProductVm>(p)).ToList(), products.Count(), pageNumber, pageSize);


            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(r => r.Find(product1.Id)).ReturnsAsync(product1);
            mockProductRepository.Setup(r => r.GetProductById(product1.Id)).ReturnsAsync(product1);
            mockProductRepository.Setup(r => r.GetAllProductsPaginatedList(pageNumber, pageSize)).ReturnsAsync(paginatedList);
            return mockProductRepository;
        }
    }
}

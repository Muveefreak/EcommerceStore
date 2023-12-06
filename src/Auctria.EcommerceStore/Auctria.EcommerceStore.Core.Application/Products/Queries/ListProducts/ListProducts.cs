using Auctria.EcommerceStore.Core.Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Auctria.EcommerceStore.Core.Application.Products.Queries.ListProducts;

public record ListProductsWithPaginationQuery : IRequest<PaginatedList<ProductVm>>
{
    public int Id { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class ListProductsWithPaginationQueryHandler : IRequestHandler<ListProductsWithPaginationQuery, PaginatedList<ProductVm>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductsWithPaginationQueryHandler(IProductRepository productRepository, 
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductVm>> Handle(ListProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllPaginatedList(request.PageNumber, request.PageSize);
    }
}
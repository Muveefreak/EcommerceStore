﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auctria.EcommerceStore.Core.Application.Products.Queries.GetProduct;

public record GetProductByIdQuery : IRequest<ProductVm>
{
    public int Id { get; init; }
}


public class GetProductQueryHandler : IRequestHandler<GetProductByIdQuery, ProductVm>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductQueryHandler> _logger;

    public GetProductQueryHandler(IProductRepository productRepository,
        IMapper mapper, ILogger<GetProductQueryHandler> logger, ICacheApplicationService<Product> cacheApplicationService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var productId = request.Id;

        var product = await _productRepository.GetProductById(productId);

        if (product == null) throw new NotFoundException(nameof(Product), request.Id);

        return product.ToVm();
    }
}


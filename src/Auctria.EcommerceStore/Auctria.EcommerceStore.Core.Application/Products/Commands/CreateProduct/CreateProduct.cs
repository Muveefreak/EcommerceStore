using AutoMapper;
using FluentValidation;
using MediatR;

namespace Auctria.EcommerceStore.Core.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public float UnitPrice { get; init; }
    public string SKU { get; init; }
    public int Stock { get; init; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository
            .FirstOrDefaultAsync(l => l.SKU == request.SKU || l.Name == request.Name);

        if (productEntity != null)
            throw new InvalidOperationException("Duplicate record");

        Product productToCreate = new Product();
        productToCreate.SKU = request.SKU;
        productToCreate.UnitPrice = request.UnitPrice;
        productToCreate.Stock = request.Stock;
        productToCreate.Description = request.Description;
        productToCreate.Name = request.Name;

        await _productRepository.Insert(productToCreate);

        return productToCreate.Id;
    }
}

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Stock)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

        RuleFor(p => p.UnitPrice)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

        RuleFor(p => p.Name)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull();

        RuleFor(p => p.SKU)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull();

        RuleFor(p => p.Description)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull();
    }
}


using AutoMapper;
using FluentValidation;
using MediatR;

namespace Auctria.EcommerceStore.Core.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string Description { get; init; }
    public float UnitPrice { get; init; }
    public int Stock { get; init; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = await _productRepository
            .Find(request.Id);

        if (productToUpdate == null) throw new NotFoundException(nameof(Product), request.Id);

        productToUpdate.Description = request.Description;
        productToUpdate.UnitPrice = request.UnitPrice;
        productToUpdate.Stock = request.Stock;

        await _productRepository.Update(productToUpdate);

        return true;
    }
}

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.Id)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

        RuleFor(p => p.Stock)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

        RuleFor(p => p.UnitPrice)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

        RuleFor(p => p.Description)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull();
    }
}


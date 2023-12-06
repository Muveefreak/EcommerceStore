using AutoMapper;
using FluentValidation;
using MediatR;
using static Auctria.EcommerceStore.Core.Application.Carts.Commands.UpdateCartCommandHandler;

namespace Auctria.EcommerceStore.Core.Application.CartItems.Commands;

public record UpdateCartItemCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;

    public UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository
            .Find(request.ProductId);

        if (productEntity == null) throw new NotFoundException(nameof(Product), request.ProductId);

        if (productEntity.Stock < request.Quantity) throw new InsufficientStockException(nameof(Product), productEntity.Stock);

        var cartEntity = await _cartItemRepository
            .Find(request.Id);

        if (cartEntity != null)
            await _cartItemRepository.Update(cartEntity);
        else
            await _cartItemRepository.Insert(cartEntity);

        return true;
    }

    public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);

            RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);

            RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(-1);
        }
    }
}
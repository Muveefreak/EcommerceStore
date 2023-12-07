using AutoMapper;
using FluentValidation;
using MediatR;

namespace Auctria.EcommerceStore.Core.Application.CartItems.Commands;

public record CreateCartItemCommand : IRequest<bool>
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;

    public CreateCartItemCommandHandler(ICartItemRepository cartItemRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository
            .Find(request.ProductId);

        if (productEntity == null) throw new NotFoundException(nameof(Product), request.ProductId);

        if (productEntity.Stock < request.Quantity) throw new InsufficientStockException(nameof(Product), productEntity.Stock);

        CartItem cartItemToCreate = new CartItem();
        cartItemToCreate.CartId = request.CartId;
        cartItemToCreate.Quantity = request.Quantity;
        cartItemToCreate.ProductId = request.ProductId;

        await _cartItemRepository.Insert(cartItemToCreate);

        return true;
    }

    public class CreateCartItemValidator : AbstractValidator<CreateCartItemCommand>
    {
        public CreateCartItemValidator()
        {

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
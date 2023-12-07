using AutoMapper;
using FluentValidation;
using MediatR;
using static Auctria.EcommerceStore.Core.Application.Carts.Commands.UpdateCartCommandHandler;

namespace Auctria.EcommerceStore.Core.Application.CartItems.Commands;

public record UpdateCartItemCommand : IRequest<bool>
{
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public int Quantity { get; set; }
}

public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, bool>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;

    public UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository,
        IProductRepository productRepository)
    {
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository
            .Find(request.ProductId);

        if (productEntity == null) throw new NotFoundException(nameof(Product), request.ProductId);

        if (productEntity.Stock < request.Quantity) throw new InsufficientStockException(nameof(Product), request.ProductId);

        var cartItemToUpdate = await _cartItemRepository
            .GetCartItemByProductIdAndCartId(request.ProductId, request.CartId);

        if (cartItemToUpdate != null)
        {
            cartItemToUpdate.Quantity = request.Quantity;
            await _cartItemRepository.Update(cartItemToUpdate);
        }
        else
        {
            CartItem cartItemToCreate = new CartItem();
            cartItemToCreate.Quantity = request.Quantity;
            cartItemToCreate.ProductId = request.ProductId;
            cartItemToCreate.CartId = request.CartId;
            await _cartItemRepository.Insert(cartItemToCreate);
        }

        return true;
    }

    public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemValidator()
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
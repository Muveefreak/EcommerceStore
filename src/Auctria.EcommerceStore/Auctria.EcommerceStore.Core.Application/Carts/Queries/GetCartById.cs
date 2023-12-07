using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auctria.EcommerceStore.Core.Application.Carts.Query;

public record GetCartByIdQuery : IRequest<CartVm>
{
    public int Id { get; init; }
}


public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, CartVm>
{
    private readonly ICartRepository _cartRepository;

    public GetCartByIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    public async Task<CartVm> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetCartById(request.Id);

        if (cart == null) throw new NotFoundException(nameof(Cart), request.Id);

        return cart.ToVm();
    }
}

public class GetCartByIdValidator : AbstractValidator<GetCartByIdQuery>
{
    public GetCartByIdValidator()
    {
        RuleFor(p => p.Id)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);
    }
}


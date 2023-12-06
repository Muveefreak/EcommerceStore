using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auctria.EcommerceStore.Core.Application.Carts.Query;

public record GetCartQuery : IRequest<CartVm>
{
    public int Id { get; init; }
}


public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartVm>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCartQueryHandler> _logger;

    public GetCartQueryHandler(ICartRepository cartRepository,
        IMapper mapper, ILogger<GetCartQueryHandler> logger)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<CartVm> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.FindById(request.Id);

        if (cart == null) throw new NotFoundException(nameof(Cart), request.Id);

        return cart.ToVm();
    }
}

public class GetCartValidator : AbstractValidator<GetCartQuery>
{
    public GetCartValidator()
    {
        RuleFor(p => p.Id)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);
    }
}


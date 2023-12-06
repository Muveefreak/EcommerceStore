using AutoMapper;
using FluentValidation;
using MediatR;

namespace Auctria.EcommerceStore.Core.Application.Carts.Commands;

public record CreateCartCommand : IRequest<int>
{
    public int CustomerId { get; init; }
    public List<CreateCartItemVm> CartItems { get; init; }
}

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;

    public CreateCartCommandHandler(ICartRepository CartRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _cartRepository = CartRepository;
    }

    public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        Cart cartToCreate = new Cart();
        cartToCreate.CustomerId = request.CustomerId;

        await _cartRepository.Insert(cartToCreate);

        return cartToCreate.Id;
    }

    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartValidator()
        {
            RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);
        }
    }
}
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Auctria.EcommerceStore.Core.Application.Carts.Commands;

public record UpdateCartCommand : IRequest<bool>
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public List<UpdateCartItemVm> CartItems { get; init; }
}

public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;

    public UpdateCartCommandHandler(ICartRepository CartRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _cartRepository = CartRepository;
    }

    public async Task<bool> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cartToUpdate = await _cartRepository
            .Find(request.Id);

        if (cartToUpdate == null) throw new NotFoundException(nameof(Cart), request.Id);

        await _cartRepository.Update(cartToUpdate);

        return true;
    }

    public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartValidator()
        {
            RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);

            RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);
        }
    }
}
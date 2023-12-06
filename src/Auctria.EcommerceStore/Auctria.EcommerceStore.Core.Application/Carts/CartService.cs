using MediatR;
using System.Transactions;

namespace Auctria.EcommerceStore.Core.Application.Carts;

public class CartService : ICartService
{
    private readonly IMediator _mediator;
    public CartService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<int> CreateCartService(CreateCartCommand request)
    {
        var result = await _mediator.Send(request);

        if (request.CartItems.Count > 0)
        {
            List<Task> tasks = new List<Task>();

            foreach(var cartItem in  request.CartItems)
            {
                var task = _mediator.Send(new CreateCartItemCommand
                {
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.ProductId,
                    CartId = result,
                });

                tasks.Add(task);
            };

            await Task.WhenAll(tasks);
        }

        return result;
    }

    public async Task<bool> UpdateCartService(UpdateCartCommand request)
    {
        var result = await _mediator.Send(request);

        if (request.CartItems.Count > 0)
        {
            List<Task> tasks = new List<Task>();

            foreach (var cartItem in request.CartItems)
            {
                var task = _mediator.Send(new UpdateCartItemCommand
                {
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.ProductId,
                    CartId = cartItem.CartId
                });

                tasks.Add(task);
            };

            await Task.WhenAll(tasks);
        }

        return true;
    }
}

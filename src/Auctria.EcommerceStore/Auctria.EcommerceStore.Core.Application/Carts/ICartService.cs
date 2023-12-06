namespace Auctria.EcommerceStore.Core.Application.Carts;

public interface ICartService
{
    Task<int> CreateCartService(CreateCartCommand request);
    Task<bool> UpdateCartService(UpdateCartCommand request);
}

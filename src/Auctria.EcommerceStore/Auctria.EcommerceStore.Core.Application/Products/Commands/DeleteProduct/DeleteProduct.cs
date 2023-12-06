using MediatR;

namespace Auctria.EcommerceStore.Core.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand : IRequest
{
    public int Id { get; init; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository
            .FirstOrDefaultAsync(l => l.Id == request.Id);

        if (productEntity.Stock > 0)
            throw new InvalidOperationException("Product can not be deleted if stock remains");

        await _productRepository.Delete(productEntity);
    }
}

using MediatR;

namespace Auctria.EcommerceStore.Core.Application.Common.Behaviours;

public class DbTransactionBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly EcommerceStoreDbContext _context;

    public DbTransactionBehaviour(EcommerceStoreDbContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database
            .BeginTransactionAsync(cancellationToken);
        try
        {
            var result = await next();
            await transaction.CommitAsync(cancellationToken);
            return result;
        }
        catch(Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

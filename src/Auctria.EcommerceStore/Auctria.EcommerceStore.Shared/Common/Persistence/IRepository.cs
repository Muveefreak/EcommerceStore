using System.Linq.Expressions;

namespace Auctria.EcommerceStore.Core.Application.Common.Persistence
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        Task<IQueryable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> Get(object id);

        Task<TEntity> Find(object id);

        Task<bool> Delete(TEntity entityToDelete);

        Task<bool> Delete(object id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entityToUpdate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        Task<List<TEntity>> GetAllAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Auctria.EcommerceStore.Infrastructure.Persistence.Repository
{
    public class Repository<TEntity, TDataContext> : IRepository<TEntity>
        where TEntity : class
        where TDataContext : DbContext
    {
        protected readonly TDataContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(TDataContext dataContext)
        {
            Context = dataContext;
            DbSet = Context.Set<TEntity>();
        }

        public virtual async Task<IQueryable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual async Task<TEntity> Get(object id)
        {
            var result = await DbSet.FindAsync(id);

            if (result == null)
            {
                throw new NotFoundException($"Entity of type {nameof(TEntity)} with ID {id} has not been found!");
            }

            return result;
        }

        public virtual async Task<TEntity> Find(object id)
        {
            if (id == null)
            {
                return null;
            }

            return await DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            DbSet.Remove(entityToDelete);
            return await Context.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(object id)
        {
            TEntity entityToDelete = await DbSet.FindAsync(id);
            return await Delete(entityToDelete);
        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entityToUpdate)
        {
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entityToUpdate;
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}

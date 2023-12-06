using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Auctria.EcommerceStore.Infrastructure.Persistence.Context
{
    public class EcommerceStoreDbContext : DbContext
    {
        public EcommerceStoreDbContext(DbContextOptions<EcommerceStoreDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

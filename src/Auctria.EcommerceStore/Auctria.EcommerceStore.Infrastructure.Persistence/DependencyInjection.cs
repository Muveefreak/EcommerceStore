using Auctria.EcommerceStore.Core.Application.Carts;
using Auctria.EcommerceStore.Core.Application.Common.Behaviours;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<EcommerceStoreDbContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("EcommerceStoreConnectionString")));

        services.AddDbContext<EcommerceStoreDbContext>(options =>
        {
            options.UseInMemoryDatabase("EcommerceStoreDbContextInMemoryTest");
            options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        });

        //services.AddTransient(typeof(IRepository<>), typeof(Repository<,>));
        services.AddTransient<ICartItemRepository, CartItemRepository>();
        services.AddTransient<ICartRepository, CartRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(DbTransactionBehaviour<,>));
        });

        services.AddScoped<EcommerceStoreDbContextInitialiser>();

        return services;
    }
}

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Builder;

namespace Auctria.EcommerceStore.Infrastructure.Persistence.Context;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<EcommerceStoreDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class EcommerceStoreDbContextInitialiser
{
    private readonly ILogger<EcommerceStoreDbContextInitialiser> _logger;
    private readonly EcommerceStoreDbContext _context;

    public EcommerceStoreDbContextInitialiser(ILogger<EcommerceStoreDbContextInitialiser> logger, EcommerceStoreDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            //await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        if (!_context.Products.Any())
        {
            _context.Products.AddRange([
                new Product { Name = "Coke", Description = "Drink", SKU = "CKE", Stock = 5, UnitPrice = 10f },
                new Product { Name = "Fanta", Description = "Drink", SKU = "FTA", Stock = 5, UnitPrice = 10f },
            ]);

            await _context.SaveChangesAsync();
        }
    }
}

using AuctionApp_dissysLabb2.Data;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;
namespace AuctionApp_dissysLabb2.Persistence;

public static class MySqlAuctionPersistence
{
    public static IServiceCollection AddMySqlAuctionPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AuctionDbContext>(options => options.UseMySQL(connectionString).EnableDetailedErrors().EnableSensitiveDataLogging());
        return services;
    }

    public static async Task AddMySqlAuctionPersistence(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        
        var auction = serviceProvider.GetRequiredService<AuctionDbContext>();
        await auction.Database.MigrateAsync();
    }
}
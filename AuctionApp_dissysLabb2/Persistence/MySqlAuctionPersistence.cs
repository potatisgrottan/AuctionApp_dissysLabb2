using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;
using AuctionApp_dissysLabb2.Data;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;
namespace AuctionApp_dissysLabb2.Persistence;

public class MySqlAuctionPersistence : IAuctionPersistence
{
    public static IServiceCollection AddMySqlAuctionPersistence(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AuctionDbContext>(options => options.UseMySQL(connectionString).EnableDetailedErrors().EnableSensitiveDataLogging());
        return services;
    }


    public Auction? GetAuctionById(int id)
    {
        throw new NotImplementedException();
    }

    public Auction? GetAuctionWithBids(int id)
    {
        throw new NotImplementedException();
    }

    public List<Auction> GetActiveAuctions()
    {
        throw new NotImplementedException();
    }

    public void AddAuction(Auction auction)
    {
        throw new NotImplementedException();
    }

    public void AddBid(Bid bid)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }
}
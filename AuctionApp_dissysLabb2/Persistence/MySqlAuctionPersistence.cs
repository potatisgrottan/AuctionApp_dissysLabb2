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
    
    private readonly AuctionDbContext _dbContext;
    public MySqlAuctionPersistence(AuctionDbContext dbContext){_dbContext = dbContext;}


    public Auction? GetAuctionById(int id)
    {
        return _dbContext.Auctions
            .Include(a => a.Bids).FirstOrDefault(a => a.Id == id);
    }

    public List<Auction> GetWonAuctions(string user)
    {
        return _dbContext.Auctions.Where(a => a.HighestBidder == user && a.IsAuctionOver()).ToList();
    }   

    public List<Auction> GetAuctionWithUserBid(string user)
    {
        return _dbContext.Auctions.Include(a => a.Bids)
            .Where(a => a.Bids.Any(b => b.Bidder == user) && a.EndTime > DateTime.Now)
            .OrderBy(a => a.EndTime)
            .ToList();
    }

    public List<Auction> GetActiveAuctions()
    {
        return _dbContext.Auctions
            .Include(a => a.Bids)
            .Where(a => a.EndTime > DateTime.Now)
            .OrderBy(a => a.EndTime)
            .ToList();
    }
    
    public List<Auction> GetAllAuctions()
    {
        return _dbContext.Auctions
            .Include(a => a.Bids)
            .ToList();
    }

    public void AddAuction(Auction auction)
    {
        _dbContext.Auctions.Add(auction);
    }

    public void AddBid(Bid bid)
    {
        _dbContext.Bids.Add(bid);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}
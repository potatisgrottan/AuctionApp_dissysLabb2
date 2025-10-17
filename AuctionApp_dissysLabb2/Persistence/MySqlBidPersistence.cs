using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp_dissysLabb2.Persistence;

public class MySqlBidPersistence : IBidPersistence
{
    private readonly AuctionDbContext _auctionDbContext;

    public MySqlBidPersistence(AuctionDbContext auctionDbContext)
    {
        _auctionDbContext = auctionDbContext;
    }
    public void AddBid(Bid bid)
    {
        _auctionDbContext.Bids.Add(bid);
    }

    public List<Bid> GetByBidder(string bidder)
    {
        return _auctionDbContext.Bids.Where(b => EF.Property<string>(b, "Bidder") == bidder).ToList();
    }

    public List<Bid> GetByAuction(int auctionId)
    {
        return _auctionDbContext.Bids.Where(b => EF.Property<int>(b, "AuctionId") == auctionId)
            .OrderByDescending(b => b.Amount)
            .ToList();
    }

    public void SaveChanges()
    {
        _auctionDbContext.SaveChanges();
    }
}
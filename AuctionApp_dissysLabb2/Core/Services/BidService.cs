using AuctionApp_dissysLabb2.Core.Interfaces;

namespace AuctionApp_dissysLabb2.Core.Services;

public class BidService : IBidService
{
    private readonly IBidPersistence _bidPersistence;
    private readonly IAuctionPersistence _auctionPersistence;

    public BidService(IBidPersistence bidPersistence, IAuctionPersistence auctionPersistence)
    {
        _bidPersistence = bidPersistence;
        _auctionPersistence = auctionPersistence;
    }
    public bool PlaceBid(int auctionId, string bidder, double amount)
    {
        if(amount <= 0) return false;
        
        var auction = _auctionPersistence.GetAuctionById(auctionId);
        if (auction == null) return false;
        if(auction.HighestBidAmount>amount) return false;
        
        auction.PlaceBid(bidder, amount);
       
        _auctionPersistence.SaveChanges();
        return true;
    }
   

    public List<Bid> GetBidsForBidder(string bidder)
    {
        return _bidPersistence.GetByBidder(bidder);
    }
}
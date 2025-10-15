using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;

namespace AuctionApp_dissysLabb2.Infrastructure;

public class MockBidService:IBidService
{

    public bool PlaceBid(int auctionId, string bidderId, double amount)
    {
        var auction = MockDataStore.Auctions.FirstOrDefault(a => a.Id == auctionId);
        if (auction == null) return false;

        bool success = auction.PlaceBid(bidderId, amount);
        if (!success) return false;

        var bid = new Bid
        {
            Id = MockDataStore.Bids.Count + 1,
            AuctionId = auctionId,
            Bidder = bidderId,
            Amount = amount,
            TimePlaced = DateTime.Now
        };

        MockDataStore.Bids.Add(bid);
        return true;
    }

    public List<Bid> GetBidsForAuction(int auctionId)
    {
        // Filtrera ut alla bud för auktionen
        return MockDataStore.Bids
            .Where(b => b.AuctionId == auctionId)
            .OrderByDescending(b => b.Amount)
            .ToList();
    }

    public List<Bid> GetBidsForBidder(string bidder)
    {
        return MockDataStore.Bids.Where(b => b.Bidder.Equals(bidder)).ToList();
    }
}
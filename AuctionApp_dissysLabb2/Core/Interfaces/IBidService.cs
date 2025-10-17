namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IBidService
{ 
        bool PlaceBid(int auctionId, string bidderId, double amount);
        
        List<Bid> GetBidsForBidder(string bidder);

}
namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IBidPersistence
{
    void AddBid(Bid bid);
    List<Bid> GetByBidder(string bidder);
    List<Bid> GetByAuction(int auctionId);
    void SaveChanges();
}
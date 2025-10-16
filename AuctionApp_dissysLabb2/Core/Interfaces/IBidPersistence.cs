namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IBidPersistence
{
    void AddBid(Bid bid);
    List<Bid> GetByBidder(int bidderId);
    List<Bid> GetByAuction(int auctionId);
    void SaveChanges();
}
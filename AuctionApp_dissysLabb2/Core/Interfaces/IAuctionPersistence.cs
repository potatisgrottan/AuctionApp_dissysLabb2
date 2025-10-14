namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IAuctionPersistence
{
    Auction? GetAuctionById(int id);
    Auction? GetAuctionWithBids(int id);
    List<Auction> GetActiveAuctions();
    void AddAuction(Auction auction);
    void AddBid(Bid bid);
    void SaveChanges();
}
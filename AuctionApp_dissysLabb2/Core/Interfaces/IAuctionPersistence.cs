namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IAuctionPersistence
{
    Auction? GetAuctionById(int id);
    List<Auction> GetWonAuctions(string user);
    List<Auction> GetActiveAuctions();
    List<Auction> GetAllAuctions();
    
    List<Auction> GetAuctionWithUserBid(string user);
    void AddAuction(Auction auction);
    
    void SaveChanges();
}
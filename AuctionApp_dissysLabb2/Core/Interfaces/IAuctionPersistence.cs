namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllAuctions();
    
    bool CreateAuction(Auction auction);
    bool EditDescription(Auction auction, string description);
    
    List<Auction> GetActiveAuctions();
    List<Auction> GetAllActiveAuctions();
    
    List<Auction> GetAuctionByItem(string name);
    
    Auction? GetAuctionDetails(int auctionId);
    
    bool PlaceBid(Auction auction, decimal amount);

    List<Auction> GetAuctionsUserBidOn(string userId);
    List <Auction> GetWonAuctions(string userId);
}
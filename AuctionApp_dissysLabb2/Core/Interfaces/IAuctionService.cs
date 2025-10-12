namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IAuctionService
{
        List<Auction> GetAllAuctions();
        bool CreateAuction(string name, string description, User seller, double startingPrice, DateTime endTime);
        bool EditDescription(int auctionId, string sellerId, string newDescription);
        List<Auction> GetActiveAuctions();  
      
        Auction? GetAuctionDetails(int auctionId);          
        bool PlaceBid(int auctionId, string bidderId, double amount);
        List<Auction> GetAuctionsUserBidOn(string userId);     
        List<Auction> GetWonAuctions(string userId);        
}
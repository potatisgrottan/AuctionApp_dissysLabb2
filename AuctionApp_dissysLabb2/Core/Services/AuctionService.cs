using AuctionApp_dissysLabb2.Core.Interfaces;

namespace AuctionApp_dissysLabb2.Core.Services;

public class AuctionService : IAuctionService
{
    private readonly IAuctionPersistence _persistence;

    public AuctionService(IAuctionPersistence persistence)
    {
        _persistence = persistence;
    }

    // 🔹 Hämtar alla auktioner
    public List<Auction> GetAllAuctions() => _persistence.GetAllAuctions();

    // 🔹 Hämtar aktiva (pågående) auktioner
    public List<Auction> GetActiveAuctions()
    {
        return _persistence.GetActiveAuctions();
    }
        

    /*public List<Auction> GetAuctionByItem(string name)
    {
        _persistence.GetAuctionById()
    }*/
        
    public Auction? GetAuctionDetails(int auctionId)
    {
        return _persistence.GetAuctionById(auctionId);
    }
    
    public bool CreateAuction(string name, string description, string seller, double startingPrice, DateTime endTime)
    {
        var auction = new Auction(name, description, seller, startingPrice, endTime);
        _persistence.AddAuction(auction);
        _persistence.SaveChanges();
        return true;
    }

    public bool EditDescription(int auctionId, string seller, string newDescription)
    {
        var auction = _persistence.GetAuctionById(auctionId);
        if (auction == null || auction.IsAuctionOver()) return false;
        if(!auction.Seller.Equals(seller)) return false;
            
        auction.Description = newDescription;
        _persistence.SaveChanges();
        return true;
    }

    
    public List<Auction> GetAuctionsUserBidOn(string user)
    {
        return _persistence.GetAuctionWithUserBid(user);
    }

    public List<Auction> GetWonAuctions(string user)
    {
        return _persistence.GetWonAuctions(user);
    }
}
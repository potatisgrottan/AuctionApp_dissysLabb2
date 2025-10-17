using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;
using ZstdSharp.Unsafe;

namespace AuctionApp_dissysLabb2.Infrastructure
{
    public class MockAuctionService : IAuctionService
    {
        

        // 🔹 Hämtar alla auktioner
        public List<Auction> GetAllAuctions() => MockDataStore.Auctions;

        // 🔹 Hämtar aktiva (pågående) auktioner
        public List<Auction> GetActiveAuctions()
        {
            return MockDataStore.Auctions.Where(a => !a.IsAuctionOver()).ToList();
        }
        

       /* public List<Auction> GetAuctionByItem(string name)
        {
            throw new NotImplementedException();
        }*/

        // 🔹 Hämtar detaljer om en specifik auktion
        public Auction? GetAuctionDetails(int auctionId)
        {
            return MockDataStore.Auctions.FirstOrDefault(a => a.Id == auctionId);
        }

        // 🔹 Skapar en ny auktion
        public bool CreateAuction(string name, string description, string seller, double startingPrice, DateTime endTime)
        {
            
            int newId = MockDataStore.Auctions.Max(a => a.Id) + 1;
            var auction = new Auction(name, description, seller, startingPrice, endTime)
            {
                Id = newId
            };
            MockDataStore.Auctions.Add(auction);
            return true;
        }

        // 🔹 Ändrar beskrivningen (bara om säljaren äger auktionen)
        public bool EditDescription(int auctionId, string seller, string newDescription)
        {
            var auction = MockDataStore.Auctions.FirstOrDefault(a => a.Id == auctionId);
            if (auction == null || auction.IsAuctionOver()) return false;
            if(!auction.Seller.Equals(seller)) return false;
            
            auction.Description = newDescription;
            return true;
        }
        

        // 🔹 Hämtar auktioner där användaren lagt bud
        public List<Auction> GetAuctionsUserBidOn(string user)
        {
            return MockDataStore.Auctions
                .Where( a=> !a.IsAuctionOver() && 
                             a.Bids.Any(b => b.Bidder.Equals(user)))
                .ToList();
        }

        // 🔹 Hämtar vunna auktioner
        public List<Auction> GetWonAuctions(string user)
        {
            return MockDataStore.Auctions
                .Where(a => a.HighestBidder != null
                            && a.HighestBidder.Equals(user)
                            && a.IsAuctionOver())
                .ToList();
        }
    }
}





using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;
using ZstdSharp.Unsafe;

namespace AuctionApp_dissysLabb2.Infrastructure
{
    public class MockAuctionService : IAuctionService
    {
        // 🔹 Statisk lista som fungerar som "fejk-databas"
        private static readonly List<User> _users = new()
        {
            new User(1, "Anna Andersson", "anna@test.com"),
            new User(2, "Björn Berg", "bjorn@test.com"),
            new User(3, "Carla Carlsson", "carla@test.com")
        };

        private static readonly List<Auction> _auctions = new()
        {
            new Auction("Gitarr", "En fin akustisk gitarr", _users[0].Name, 1000, DateTime.Now.AddDays(2))
            {
                Id = 1
            },
            new Auction("Cykel", "Mountainbike, nästan ny", _users[1].Name, 2000, DateTime.Now.AddHours(6))
            {
                Id = 2
            },
            new Auction("Bok", "Första upplagan, samlarobjekt", _users[2].Name, 500, DateTime.Now.AddDays(-1))
            {
                Id = 3
            }
        };

        // Lägg till några exempelbud
        static MockAuctionService()
        {
            _auctions[0].PlaceBid(_users[1].Name, 1200);
            _auctions[0].PlaceBid(_users[2].Name, 1400);

            _auctions[1].PlaceBid(_users[2].Name, 2100);

            _auctions[2].PlaceBid(_users[0].Name, 700);
        }

        // 🔹 Hämtar alla auktioner
        public List<Auction> GetAllAuctions() => _auctions;

        // 🔹 Hämtar aktiva (pågående) auktioner
        public List<Auction> GetActiveAuctions()
        {
            return _auctions.Where(a => !a.IsAuctionOver()).ToList();
        }

        public List<Auction> GetAllActiveAuctions()
        {
             List<Auction> activeAuctions  = _auctions.Where(auction =>  !auction.IsAuctionOver() ).ToList();
             return activeAuctions;
        }

        public List<Auction> GetAuctionByItem(string name)
        {
            throw new NotImplementedException();
        }

        // 🔹 Hämtar detaljer om en specifik auktion
        public Auction? GetAuctionDetails(int auctionId)
        {
            return _auctions.FirstOrDefault(a => a.Id == auctionId);
        }

        // 🔹 Skapar en ny auktion
        public bool CreateAuction(string name, string description, string seller, double startingPrice, DateTime endTime)
        {
            
            int newId = _auctions.Max(a => a.Id) + 1;
            var auction = new Auction(name, description, seller, startingPrice, endTime)
            {
                Id = newId
            };
            _auctions.Add(auction);
            return true;
        }

        // 🔹 Ändrar beskrivningen (bara om säljaren äger auktionen)
        public bool EditDescription(int auctionId, string seller, string newDescription)
        {
            var auction = _auctions.FirstOrDefault(a => a.Id == auctionId);
            if (auction == null || auction.IsAuctionOver()) return false;
            if(!auction.Seller.Equals(seller)) return false;
           

            auction.Description = newDescription;
            return true;
        }

        // 🔹 Lägger ett bud
        public bool PlaceBid(int auctionId, string bidderName, double amount)
        {
            var auction = _auctions.FirstOrDefault(a => a.Id == auctionId);
            

            if (auction == null || bidderName == null) return false;

            return auction.PlaceBid(bidderName, amount);
        }

        // 🔹 Hämtar auktioner där användaren lagt bud
        public List<Auction> GetAuctionsUserBidOn(string user)
        {
            return _auctions
                .Where(a => a.Bids.Any(b => b.Bidder.Equals(user)))
                .ToList();
        }

        // 🔹 Hämtar vunna auktioner
        public List<Auction> GetWonAuctions(string user)
        {
            return _auctions
                .Where(a => a.HighestBidder != null
                            && a.HighestBidder.Equals(user)
                            && a.IsAuctionOver())
                .ToList();
        }
    }
}



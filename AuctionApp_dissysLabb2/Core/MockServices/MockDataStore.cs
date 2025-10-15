using AuctionApp_dissysLabb2.Core;

namespace AuctionApp_dissysLabb2.Infrastructure
{
    public static class MockDataStore
    {
        public static List<User> Users { get; } = new()
        {
            new User(1, "Anna Andersson", "anna@test.com"),
            new User(2, "Björn Berg", "bjorn@test.com"),
            new User(3, "Carla Carlsson", "carla@test.com")
        };

        public static List<Auction> Auctions { get; } = new()
        {
            new Auction("Gitarr", "En fin akustisk gitarr", "Anna Andersson", 1000, DateTime.Now.AddDays(2)) { Id = 1 },
            new Auction("Cykel", "Mountainbike, nästan ny", "Björn Berg", 2000, DateTime.Now.AddHours(6)) { Id = 2 },
            new Auction("Bok", "Första upplagan, samlarobjekt", "Carla Carlsson", 500, DateTime.Now.AddDays(-1)) { Id = 3 }
        };

        public static List<Bid> Bids { get; } = new();

        static MockDataStore()
        {
            // Lite startdata
            Auctions[0].PlaceBid("Björn Berg", 1200);
            Auctions[0].PlaceBid("Carla Carlsson", 1400);
            Auctions[1].PlaceBid("Carla Carlsson", 2100);
            Auctions[2].PlaceBid("Anna Andersson", 700);
        }
    }
}

namespace AuctionApp_dissysLabb2.Core
{
    public class Auction
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Seller { get; private set; } = null!;
        public int SellerId { get; set; }

        public double StartingPrice { get; set; }
        public double HighestBidAmount { get; private set; }

        public string HighestBidder { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; set; }

        public List<Bid> Bids { get; set; } = new();

        public Auction() { } 

        public Auction(string name, string description, string seller, double startingPrice, DateTime endTime)
        {
            Name = name;
            Description = description;
            Seller = seller;
            StartingPrice = startingPrice;
            HighestBidAmount = startingPrice;
            StartTime = DateTime.Now;
            EndTime = endTime;
        }

        public bool IsAuctionOver()
        {
            return DateTime.Now > EndTime;
        }

        public bool PlaceBid(string? bidder, double amount)
        {
            if (IsAuctionOver()) return false;
            if (bidder == null || bidder.Equals(Seller)) return false;
            if (amount <= HighestBidAmount) return false;

            HighestBidAmount = amount;
            HighestBidder = bidder;
            Bids.Add(new Bid( Id,bidder, amount, DateTime.Now));

            return true;
        }
    }
}

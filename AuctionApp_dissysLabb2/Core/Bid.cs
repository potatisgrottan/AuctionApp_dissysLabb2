namespace AuctionApp_dissysLabb2.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public User Bidder { get; set; } = null!;
        public int BidderId { get; set; }

        public double Amount { get; set; }
        public DateTime TimePlaced { get; set; }

        public Bid() { }

        public Bid(User bidder, double amount, DateTime timePlaced)
        {
            Bidder = bidder;
            Amount = amount;
            TimePlaced = timePlaced;
        }
    }
}

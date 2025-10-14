namespace AuctionApp_dissysLabb2.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public string Bidder { get; set; } = null!;
       

        public double Amount { get; set; }
        public DateTime TimePlaced { get; set; }

        public Bid() { }

        public Bid(string bidder, double amount, DateTime timePlaced)
        {
            Bidder = bidder;
            Amount = amount;
            TimePlaced = timePlaced;
        }
    }
}

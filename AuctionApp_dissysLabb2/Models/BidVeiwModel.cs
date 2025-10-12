namespace AuctionApp_dissysLabb2.Models;

public class BidVeiwModel
{
        public string BidderName { get; set; } = string.Empty;
        public double Amount { get; set; }
        public DateTime TimePlaced { get; set; }

        public static BidVeiwModel FromBid(BidVeiwModel model)
        {
                return new BidVeiwModel()
                {
                        BidderName = model.BidderName,
                        Amount = model.Amount,
                        TimePlaced = model.TimePlaced,
                };
        }
}
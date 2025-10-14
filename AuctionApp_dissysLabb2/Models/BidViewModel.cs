using AuctionApp_dissysLabb2.Core;

namespace AuctionApp_dissysLabb2.Models;

public class BidViewModel
{
        public string BidderName { get; set; } = string.Empty;
        public double Amount { get; set; }
        public DateTime TimePlaced { get; set; }

        public static BidViewModel FromBid(Bid bid)
        {
                return new BidViewModel()
                {
                        BidderName = bid.Bidder,
                        Amount = bid.Amount,
                        TimePlaced = bid.TimePlaced,
                };
        }
}
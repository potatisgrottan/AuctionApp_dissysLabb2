using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AuctionApp_dissysLabb2.Core;

namespace AuctionApp_dissysLabb2.Models;

public class AuctionDetailsViewModel
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string SellerName { get; set; } = string.Empty;

    public double StartingPrice { get; set; }
    public double HighestBidAmount { get; set; }

    public string HighestBidderName { get; set; } = string.Empty;
        
    public DateTime StartTime { get; set; }
        
    [DisplayName("auction close time")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EndTime { get; set; }

    public bool IsOver => DateTime.Now > EndTime;

    public List<BidViewModel> BidsVM = new();

    public static AuctionDetailsViewModel FromAuction(Auction auction)
    {
        var detailsVM = new AuctionDetailsViewModel()
        {
            Id = auction.Id,
            Name = auction.Name,
            Description = auction.Description,
            SellerName = auction.Seller?.Name ?? "no seller",
            StartingPrice = auction.StartingPrice,
            HighestBidAmount = auction.HighestBidAmount,
            HighestBidderName = auction.HighestBidder?.Name ?? "no bids yet",
            StartTime = auction.StartTime,
            EndTime = auction.EndTime,
        };
        foreach (var bid in  auction.Bids )
        {
            detailsVM.BidsVM.Add(BidViewModel.FromBid(bid));
        }
        return detailsVM;
    }

}
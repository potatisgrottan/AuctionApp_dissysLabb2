using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AuctionApp_dissysLabb2.Core;

namespace AuctionApp_dissysLabb2.Models;

public class AuctionDetailsViewModel
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }

    [Display(Name = "Item being auctioned:")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Item description:")] 
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Seller:")]
    public string SellerName { get; set; } = string.Empty;

    [Display(Name = "Start price:")]
    public double StartingPrice { get; set; }
    
    [Display(Name = "Highest bid:")]
    public double HighestBidAmount { get; set; }

    [Display(Name = "Highest bidders name:")]
    public string HighestBidderName { get; set; } = string.Empty;
        
    [Display(Name = "Auction start date:")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime StartTime { get; set; }
        
    [DisplayName("Auction end date:")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime EndTime { get; set; }

    [ScaffoldColumn(false)]
    public bool IsOver => DateTime.Now > EndTime;

    public List<BidViewModel> BidsVM { get; set; } = new();

    public static AuctionDetailsViewModel FromAuction(Auction auction)
    {
        var detailsVM = new AuctionDetailsViewModel()
        {
            Id = auction.Id,
            Name = auction.Name,
            Description = auction.Description,
            SellerName = auction.Seller,
            StartingPrice = auction.StartingPrice,
            HighestBidAmount = auction.HighestBidAmount,
            HighestBidderName = auction.HighestBidder,
            StartTime = auction.StartTime,
            EndTime = auction.EndTime,
        };
        foreach (var bid in  auction.Bids )
        {
            detailsVM.BidsVM.Add(BidViewModel.FromBid(bid));
        }
        detailsVM.BidsVM = detailsVM.BidsVM.OrderByDescending(b => b.Amount).ToList();
        return detailsVM;
    }

}
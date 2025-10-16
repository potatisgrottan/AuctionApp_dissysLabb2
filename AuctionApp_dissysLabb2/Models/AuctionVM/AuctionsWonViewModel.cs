using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AuctionApp_dissysLabb2.Core;

namespace AuctionApp_dissysLabb2.Models;

public class AuctionsWonViewModel
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }

    [DisplayName("Item that was sold:")]
    public string Name { get; set; } = string.Empty;
        
    [DisplayName("Description:")]
    public string Description { get; set; } = string.Empty;

    [DisplayName("Seller:")]
    public string SellerName { get; set; } = string.Empty;

    [DisplayName("Starting price:")]
    public double StartingPrice { get; set; }
        
    [DisplayName("The final price for this auction was:")]
    public double HighestBidAmount { get; set; }
  
    [DisplayName("Name of winner:")]
    public string HighestBidderName { get; set; } = string.Empty;
        
    [DisplayName("This auction started:")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime StartTime { get; set; }
        
    [DisplayName("This auction ended:")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime EndTime { get; set; }

    public bool IsOver => DateTime.Now > EndTime;

        
    public static AuctionsWonViewModel FromAuction(Auction auction)
    {
        return new AuctionsWonViewModel()
        {
            Id = auction.Id,
            Name= auction.Name,
            Description = auction.Description,
            SellerName = auction.Seller,
            StartingPrice = auction.StartingPrice,
            HighestBidAmount = auction.HighestBidAmount,
            HighestBidderName = auction.HighestBidder,
            StartTime = auction.StartTime,
            EndTime = auction.EndTime,
        };
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AuctionApp_dissysLabb2.Core;


namespace AuctionApp_dissysLabb2.Models;

public class AuctionViewModel
{
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Item:")]
        public string Name { get; set; } = string.Empty;
        
        [DisplayName("Description:")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Seller:")]
        public string SellerName { get; set; } = string.Empty;

        [DisplayName("Starting price:")]
        public double StartingPrice { get; set; }
        
        [DisplayName("Highest bid:")]
        public double HighestBidAmount { get; set; }

        [DisplayName("Highest bidders name:")]
        public string HighestBidderName { get; set; } = string.Empty;
        
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartTime { get; set; }
        
        [DisplayName("End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime EndTime { get; set; }

        public bool IsOver => DateTime.Now > EndTime;

        
        public static AuctionViewModel FromAuction(Auction auction)
        {
                return new AuctionViewModel()
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
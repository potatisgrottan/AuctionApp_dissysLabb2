using System.ComponentModel.DataAnnotations;

namespace AuctionApp_dissysLabb2.Models;

public class BidCreateViewModel
{
    [ScaffoldColumn(false)]
    public int AuctionId { get; set; }
    [Required]
    [Display(Name = "Bid amount")]
    public double Amount { get; set; }
}
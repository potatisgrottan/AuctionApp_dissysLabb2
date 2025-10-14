using System.ComponentModel.DataAnnotations;

namespace AuctionApp_dissysLabb2.Models;

public class AuctionCreateViewModel
{
    [Required(ErrorMessage = "item name cant be empty")]
    [StringLength(100)]
    [Display(Name = "Name of item you are auctioning out")]
    public string ItemName { get; set; } = string.Empty;

    [Required(ErrorMessage = "item description cant be empty")]
    [StringLength(500)]
    [Display(Name = "Description of item you are auctioning out")]
    public string Description { get; set; } = string.Empty;

    [Required (ErrorMessage = "starting price is reqired")]
    [Range(1, 1000000)]
    [Display(Name = "Starting price")]
    public double StartingPrice { get; set; }

    [Required(ErrorMessage = "End date cant be empty")]
    [Display(Name = "End date for auction")]
    public DateTime EndDate { get; set; }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuctionApp_dissysLabb2.Models;

public class AuctionEditViewModel
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    
    [ReadOnly(true)]
    [Display(Name = "Item Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Description")]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
}
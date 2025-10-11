using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp_dissysLabb2.Persistence;

public class TaskDb
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(256)]
    public string Description { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime LastUpdated { get; set; }
    
    [Required]
    //public Status Status { get; set; }
    
    [ForeignKey("ProjectId")]
    public ProjectDb ProjectDb { get; set; }
    public int ProjectId { get; set; }
}
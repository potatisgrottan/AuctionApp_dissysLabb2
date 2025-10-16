using AuctionApp_dissysLabb2.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionApp_dissysLabb2.Configuration;

public class BidConfiguration:IEntityTypeConfiguration<Bid>
{
    public void Configure(EntityTypeBuilder<Bid> builder)
    {
        builder.ToTable("Bids");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.TimePlaced).IsRequired();
        
        //Foreign Key
        builder.HasOne(x => x.Bidder).WithMany().HasForeignKey("BidderId");
    }
}
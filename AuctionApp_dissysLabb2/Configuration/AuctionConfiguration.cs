using AuctionApp_dissysLabb2.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionApp_dissysLabb2.Configuration;

public class AuctionConfiguration: IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
        builder.ToTable("Auctions");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x =>x.StartingPrice).IsRequired();
        builder.Property(x=>x.StartTime).IsRequired();
        builder.Property(x=>x.EndTime).IsRequired();
        
        //Foreign Key
        builder.HasOne(x => x.Seller).WithMany().HasForeignKey(x => x.SellerId);

        builder.Ignore(x => x.HighestBidAmount);
        builder.Ignore(x => x.HighestBidder);
    }
}
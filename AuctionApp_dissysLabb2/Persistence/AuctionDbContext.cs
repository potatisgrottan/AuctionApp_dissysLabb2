using AuctionApp_dissysLabb2.Configuration;
using AuctionApp_dissysLabb2.Core;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp_dissysLabb2.Persistence;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options){ }

    
    public DbSet<Bid> Bids => Set<Bid>();
    public DbSet<Auction> Auctions => Set<Auction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BidConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionConfiguration());
    }
}
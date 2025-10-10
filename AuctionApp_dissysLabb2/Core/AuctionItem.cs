using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp_dissysLabb2.Core;

public class AuctionItem
{
    
    private string name;
    
    private double highestBid;
    
    private int highestBidder; //userId
    
    private DateTime startTime;
    
    private DateTime endTime;
    
    private string description;
    
    public AuctionItem(int highestBidder, double highestBid, string name, DateTime endTime, string description)
    {
        startTime = DateTime.Now;
        this.highestBid = highestBid;
        this.highestBidder = highestBidder;
        this.name = name;
        this.endTime = endTime;
        this.description = description;
        
    }

    public string getName()
    {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public double getHighestBidder()
    {
        return highestBidder;
    }

    public void setHighestBidder(int highestBidder)
    {
        this.highestBidder = highestBidder;
    }

    public string getDescription()
    {
        return description;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public bool isAuctionOver()
    {
        return DateTime.Compare(endTime, DateTime.Now) == 1;
    }
    
}
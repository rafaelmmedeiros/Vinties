namespace AuctionService.Entities;

public class Auction
{
    public Auction(string seller, decimal reservePrice)
    {
        Seller = seller;
        ReservePrice = reservePrice;
    }

    public Guid Id { get; set; }

    public string Seller { get; set; }
    public string? Winner { get; set; } = null!;

    public decimal ReservePrice { get; set; }
    public int? SoldAmount { get; set; }
    public int? CurrentHigBid { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public DateTime? AuctionEnded { get; set; }

    public AuctionStatus Status { get; set; } = AuctionStatus.Live;

    public AuctionItem Item { get; set; } = null!;
}

public enum AuctionStatus
{
    Live,
    Finished,
    ReservedNotMet
}
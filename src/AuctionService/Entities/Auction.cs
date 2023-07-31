namespace AuctionService.Entities;

public class Auction
{
    public Guid Id { get; set; }

    public string Seller { get; set; } = null!;
    public string? Winner { get; set; }

    public int ReservePrice { get; set; }
    public int? SoldAmount { get; set; }
    public int? CurrentHigBid { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
    public DateTime AuctionEnd { get; set; }

    public AuctionStatus Status { get; set; } = AuctionStatus.Live;

    public AuctionItem Item { get; set; } = null!;
}

public enum AuctionStatus
{
    Live,
    Finished,
    ReservedNotMet
}
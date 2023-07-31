using MongoDB.Entities;

namespace SearchService.Entities;

public class Auction : Entity
{
    public string Seller { get; set; } = null!;
    public string? Winner { get; set; }
    public int ReservePrice { get; set; }
    public int? SoldAmount { get; set; }
    public int? CurrentHigBid { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string Status { get; set; } = null!;
    
    public string Model { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? SerialNumber { get; set; }
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
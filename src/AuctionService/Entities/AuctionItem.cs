namespace AuctionService.Entities;

public class AuctionItem
{
    public Guid Id { get; set; }

    public string Model { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public AuctionItemType Type { get; set; }
    public string? SerialNumber { get; set; }
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public Auction Auction { get; set; } = null!;
    public Guid AuctionId { get; set; }
}

public enum AuctionItemType
{
    Guitar,
    Amplifier,
    Pedal,
    MultiEffect,
    BassGuitar
}
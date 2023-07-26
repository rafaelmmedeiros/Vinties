namespace AuctionService.Entities;

public class AuctionItem
{
    public AuctionItem(string model, string manufacturer, string description, AuctionItemType type, string? serialNumber, int year, string color, string imageUrl)
    {
        Model = model;
        Manufacturer = manufacturer;
        Description = description;
        Type = type;
        SerialNumber = serialNumber;
        Year = year;
        Color = color;
        ImageUrl = imageUrl;
    }

    public Guid Id { get; set; }

    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string Description { get; set; }
    public AuctionItemType Type { get; set; }
    
    public string? SerialNumber { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

    public string? ImageUrl { get; set; }

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
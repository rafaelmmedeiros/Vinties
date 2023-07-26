namespace AuctionService.DTOs;

public class AuctionUpdateDto
{
    public string Model { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? SerialNumber { get; set; }
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
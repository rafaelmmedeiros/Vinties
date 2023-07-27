namespace AuctionService.DTOs;

public class AuctionUpdateDto
{
    public string Description { get; set; } = null!;
    public string? SerialNumber { get; set; }
    public string? ImageUrl { get; set; }
}
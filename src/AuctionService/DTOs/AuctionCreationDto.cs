using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTOs;

public class AuctionCreationDto
{
    [Required] public int ReservePrice { get; set; }
    [Required] public DateTime AuctionEnd { get; set; }
    
    [Required] public string Model { get; set; } = null!;
    [Required] public string Brand { get; set; } = null!;
    [Required] public string Description { get; set; } = null!;
    [Required] public string Type { get; set; } = null!;
    public string? SerialNumber { get; set; }
    [Required] public int Year { get; set; }
    [Required] public string Color { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
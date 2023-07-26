using System.ComponentModel.DataAnnotations;
using AuctionService.Entities;

namespace AuctionService.DTOs;

public class AuctionCreationDto
{
    [Required] public decimal ReservePrice { get; set; }
    [Required] public DateTime AuctionEnd { get; set; }

    [Required] public string Model { get; set; } = null!;
    [Required] public string Manufacturer { get; set; } = null!;
    [Required] public string Description { get; set; } = null!;
    [Required] public AuctionItemType Type { get; set; }
    public string? SerialNumber { get; set; }
    [Required] public int Year { get; set; }
    [Required] public string Color { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
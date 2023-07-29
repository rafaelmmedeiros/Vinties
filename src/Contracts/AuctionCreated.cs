namespace Contracts;

public class AuctionCreated
{
    public Guid Id { get; set; }
    public string Seller { get; set; }
    public string Winner { get; set; }
    public decimal ReservePrice { get; set; }
    public int SoldAmount { get; set; }
    public int CurrentHigBid { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string Status { get; set; }
    
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string SerialNumber { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public string ImageUrl { get; set; }
}
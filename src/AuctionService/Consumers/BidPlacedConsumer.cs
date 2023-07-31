using AuctionService.Data;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class BidPlacedConsumer : IConsumer<BidPlaced>
{
    private readonly AuctionDbContext _context;

    public BidPlacedConsumer(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<BidPlaced> consumeContext)
    {
        Console.WriteLine("---> BidPlacedConsumer:");
        
        var auction = await _context.Auctions.FindAsync(consumeContext.Message.AuctionId);

        if (auction.CurrentHighBid == null 
            || consumeContext.Message.BidStatus.Contains("Accepted") 
            && consumeContext.Message.Amount > auction.CurrentHighBid)
        {
            auction.CurrentHighBid = consumeContext.Message.Amount;
        }
        
        await _context.SaveChangesAsync();
    }
}
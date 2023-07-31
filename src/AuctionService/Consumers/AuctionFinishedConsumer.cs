using AuctionService.Data;
using AuctionService.Entities;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
{
    private readonly AuctionDbContext _context;

    public AuctionFinishedConsumer(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<AuctionFinished> consumeContext)
    {
        Console.WriteLine("---> AuctionFinishedConsumer:");
        
        var auction = await _context.Auctions.FindAsync(consumeContext.Message.AuctionId);

        if (consumeContext.Message.ItemSold)
        {
            auction.Winner = consumeContext.Message.Winner;
            auction.SoldAmount = consumeContext.Message.Amount;
        }

        auction.Status = auction.SoldAmount >= auction.ReservePrice
            ? AuctionStatus.Finished
            : AuctionStatus.ReservedNotMet;

        await _context.SaveChangesAsync();
    }
}
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Consumers;

public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
{
    public async Task Consume(ConsumeContext<AuctionFinished> consumeContext)
    {
        Console.WriteLine("AuctionFinishedConsumer:");
        
        var auction = await DB.Find<Auction>().OneAsync(consumeContext.Message.AuctionId);

        if (consumeContext.Message.ItemSold)
        {
            auction.Winner = consumeContext.Message.Winner;
            auction.SoldAmount = consumeContext.Message.Amount;
        }
        
        auction.Status = "Finished";
        await auction.SaveAsync();
    }
}
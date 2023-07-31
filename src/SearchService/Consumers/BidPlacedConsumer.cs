using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Consumers;

public class BidPlacedConsumer : IConsumer<BidPlaced>
{
    public async Task Consume(ConsumeContext<BidPlaced> consumeContext)
    {
        Console.WriteLine("BidPlacedConsumer: ");
        
        var auction = await DB.Find<Auction>().OneAsync(consumeContext.Message.AuctionId);

        if (auction.CurrentHighBid == null 
            || consumeContext.Message.BidStatus.Contains("Accepted")
            && consumeContext.Message.Amount > auction.CurrentHighBid)
        {
            auction.CurrentHighBid = consumeContext.Message.Amount;
            await auction.SaveAsync();
        }
    }
}
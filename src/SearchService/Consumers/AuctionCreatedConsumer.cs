using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper;

    public AuctionCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("---> AuctionCreatedConsumer " + context.Message.Id);
        var auction = _mapper.Map<Auction>(context.Message);

        // Test purpose
        if (auction.Brand == "Foo") throw new ArgumentException("Foo is not a valid brand");
        
        await auction.SaveAsync();
    }
}
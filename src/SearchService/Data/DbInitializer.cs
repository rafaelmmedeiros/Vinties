using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Entities;
using SearchService.Services;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task UnitDbInit(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
            MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Auction>()
            .Key(a => a.Model, KeyType.Text)
            .Key(a => a.Brand, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Auction>();

        using var scope = app.Services.CreateScope();
        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();
        var items = await httpClient.SyncItemsFromAuctionService();
        
        Console.WriteLine(items.Count + " items received from AuctionService");
        if (items.Count > count) await DB.SaveAsync(items);
    }
}
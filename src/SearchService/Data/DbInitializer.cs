using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task UnitDbInit(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
            MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Auction>()
            .Key(a => a.Model, KeyType.Text)
            .Key(a => a.Manufacturer, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Auction>();

        if (count == 0)
        {
            Console.WriteLine("Seeding database...");
            var auctions = await File.ReadAllTextAsync("Data/auctions.json");
            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
            var auctionList = JsonSerializer.Deserialize<List<Auction>>(auctions, options);
            await DB.SaveAsync(auctionList);
        }
    }
}
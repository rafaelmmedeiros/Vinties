using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Services;

public class AuctionSvcHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AuctionSvcHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<List<Auction>?> SyncItemsFromAuctionService()
    {
        var lastUpdatedDate = await DB.Find<Auction, string>()
            .Sort(auction => auction.Descending(field => field.Updated))
            .Project(auction => auction.Updated.ToString())
            .ExecuteFirstAsync();
        
        return await _httpClient.GetFromJsonAsync<List<Auction>>(
            $"{_configuration["AuctionServiceUrl"]}/api/auctions?date={lastUpdatedDate}");
    }
}
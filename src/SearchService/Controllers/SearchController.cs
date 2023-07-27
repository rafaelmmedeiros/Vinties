using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Auction>>> SearchAuctions([FromQuery] string? searchTerm)
    {
        var query = DB.Find<Auction>();
        query.Sort(auction => auction.Ascending(field => field.AuctionEnd));
        
        if (!string.IsNullOrEmpty(searchTerm))
            query.Match(Search.Full, searchTerm).SortByTextScore();
        
        var results = await query.ExecuteAsync();
        return Ok(results);
    }
}
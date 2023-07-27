using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Auction>>> SearchAuctions([FromQuery] string? searchTerm, int page = 1, int pageSize = 5)
    {
        var query = DB.PagedSearch<Auction>();
        query.Sort(auction => auction.Ascending(field => field.AuctionEnd));
        
        if (!string.IsNullOrEmpty(searchTerm))
            query.Match(Search.Full, searchTerm).SortByTextScore();
        
        query.PageNumber(page).PageSize(pageSize);
        
        var results = await query.ExecuteAsync();
        return Ok(new
        {
            results = results.Results,
            pageCount = results.PageCount,
            totalCount = results.TotalCount,
        });
    }
}
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Entities;
using SearchService.RequestHelpers;

namespace SearchService.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Auction>>> SearchAuctions([FromQuery] SearchParams searchParams)
    {
        var query = DB.PagedSearch<Auction, Auction>();
        query.Sort(auction => auction.Ascending(field => field.AuctionEnd));
        
        if (!string.IsNullOrEmpty(searchParams.SearchTerm))
            query.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();
        
        query = searchParams.OrderBy switch
        {
            "brand" => query.Sort(auction => auction.Ascending(field => field.Brand)),
            "new" => query.Sort(auction => auction.Descending(field => field.Created)),
            _ => query.Sort(auction => auction.Ascending(field => field.AuctionEnd))
        };
        
        query = searchParams.FilterBy switch
        {
            "finished" => query.Match(auction => auction.AuctionEnd < DateTime.UtcNow),
            "endingSoon" => query.Match(auction => auction.AuctionEnd < DateTime.UtcNow.AddHours(6) && auction.AuctionEnd > DateTime.UtcNow),
            _ => query.Match(auction => auction.AuctionEnd > DateTime.UtcNow)
        };
        
        if (!string.IsNullOrEmpty(searchParams.Seller)) query.Match(auction => auction.Seller == searchParams.Seller);
        if (!string.IsNullOrEmpty(searchParams.Winner)) query.Match(auction => auction.Winner == searchParams.Winner);
        
        query.PageNumber(searchParams.Page).PageSize(searchParams.PageSize);
        
        var results = await query.ExecuteAsync();
        return Ok(new
        {
            results = results.Results,
            pageCount = results.PageCount,
            totalCount = results.TotalCount,
        });
    }
}
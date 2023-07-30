using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuctionsController : ControllerBase
{
    private readonly AuctionDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public AuctionsController(AuctionDbContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuctionDto>>> GetAuctions(string? date)
    {
        var queryable = _context.Auctions.OrderBy(auction => auction.AuctionEnd).AsQueryable();

        if (!string.IsNullOrEmpty(date))
            queryable = queryable.Where(auction => auction.Updated.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        
        return Ok(await queryable.ProjectTo<AuctionDto>(_mapper.ConfigurationProvider).ToListAsync());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid id)
    {
        var auction = await _context.Auctions
            .Include(auction => auction.Item)
            .FirstOrDefaultAsync(auction => auction.Id == id);

        if (auction == null) return NotFound();

        return Ok(_mapper.Map<AuctionDto>(auction));
    }

    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<AuctionDto>> CreateAuction([FromBody]AuctionCreationDto request)
    {
        var auction = _mapper.Map<Auction>(request);
        auction.Seller = User.Identity!.Name!;
        
        _context.Auctions.Add(auction);
        
        var newAuction = _mapper.Map<AuctionDto>(auction);
        await _publishEndpoint.Publish(_mapper.Map<AuctionCreated>(newAuction));
        
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to create auction");
        
        return CreatedAtAction(nameof(GetAuctionById), new {id = auction.Id}, newAuction);
    }
    
    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAuction([FromRoute]Guid id, [FromBody]AuctionUpdateDto request)
    {
        var auction = await _context.Auctions
            .Include(auction => auction.Item)
            .FirstOrDefaultAsync(auction => auction.Id == id);

        if (auction == null) return NotFound();
        if (auction.Seller != User.Identity!.Name) return Forbid();

        auction.Item.Description = request.Description ?? auction.Item.Description;
        auction.Item.ImageUrl = request.ImageUrl ?? auction.Item.ImageUrl;
        auction.Item.SerialNumber = request.SerialNumber ?? auction.Item.SerialNumber;
        auction.Updated = DateTime.UtcNow;
        
        await _publishEndpoint.Publish(_mapper.Map<AuctionUpdated>(auction));
        
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to update auction");

        return Ok();
    }
    
    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAuction([FromRoute]Guid id)
    {
        var auction = await _context.Auctions
            .Include(auction => auction.Item)
            .FirstOrDefaultAsync(auction => auction.Id == id);

        if (auction == null) return NotFound();
        if (auction.Seller != User.Identity!.Name) return Forbid();
        
        _context.Auctions.Remove(auction);
        await _publishEndpoint.Publish<AuctionDeleted>(new { Id = auction.Id.ToString() });
        
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to delete auction");

        return Ok();
    }
}
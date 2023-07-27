using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuctionsController : ControllerBase
{
    private readonly AuctionDbContext _context;
    private readonly IMapper _mapper;

    public AuctionsController(AuctionDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuctionViewDto>>> GetAuctions()
    {
        var auctions = await _context.Auctions
            .Include(auction => auction.Item)
            .OrderBy(auction => auction.AuctionEnd)
            .ToListAsync();

        return Ok(_mapper.Map<List<AuctionViewDto>>(auctions));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AuctionViewDto>> GetAuctionById(Guid id)
    {
        var auction = await _context.Auctions
            .Include(auction => auction.Item)
            .FirstOrDefaultAsync(auction => auction.Id == id);

        if (auction == null) return NotFound();

        return Ok(_mapper.Map<AuctionViewDto>(auction));
    }
    
    [HttpPost]
    public async Task<ActionResult<AuctionViewDto>> CreateAuction(AuctionCreationDto request)
    {
        var auction = _mapper.Map<Auction>(request);
        auction.Seller = "Mark";
        
        _context.Auctions.Add(auction);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to create auction");

        return CreatedAtAction(nameof(GetAuctionById), new {id = auction.Id}, _mapper.Map<AuctionViewDto>(auction));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAuction(Guid id, AuctionUpdateDto request)
    {
        var auction = await _context.Auctions
            .Include(auction => auction.Item)
            .FirstOrDefaultAsync(auction => auction.Id == id);

        if (auction == null) return NotFound();

        auction.Item.Description = request.Description ?? auction.Item.Description;
        auction.Item.ImageUrl = request.ImageUrl ?? auction.Item.ImageUrl;
        auction.Item.SerialNumber = request.SerialNumber ?? auction.Item.SerialNumber;
        auction.Updated = DateTime.UtcNow;
        
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to update auction");

        return Ok();
    }
}
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
    public async Task<ActionResult<AuctionViewDto>> GetAuction(Guid id)
    {
        var auction = await _context.Auctions
            .Include(auction => auction.Item)
            .FirstOrDefaultAsync(auction => auction.Id == id);

        if (auction == null) return NotFound();

        return Ok(_mapper.Map<AuctionViewDto>(auction));
    }
    
    [HttpPost]
    public async Task<ActionResult<AuctionViewDto>> CreateAuction(AuctionCreationDto auctionCreationDto)
    {
        var auction = _mapper.Map<Auction>(auctionCreationDto);
        auction.Seller = "Mark";
        
        _context.Auctions.Add(auction);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAuction), new {id = auction.Id}, _mapper.Map<AuctionViewDto>(auction));
    }
}
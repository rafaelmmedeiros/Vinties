using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(auction => auction.Item);
        CreateMap<AuctionItem, AuctionDto>();
        CreateMap<AuctionCreationDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
        CreateMap<AuctionCreationDto, AuctionItem>();
    }
}
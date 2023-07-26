using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers;

public class MappingProfiles : Profile
{
    protected MappingProfiles()
    {
        CreateMap<Auction, AuctionViewDto>().IncludeMembers(auction => auction.Item);
        CreateMap<AuctionItem, AuctionViewDto>();
        CreateMap<AuctionCreationDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
        CreateMap<AuctionCreationDto, AuctionItem>();
    }
}
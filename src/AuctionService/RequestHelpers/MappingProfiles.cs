using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // CRUD Operations
        CreateMap<Auction, AuctionDto>().IncludeMembers(auction => auction.Item);
        CreateMap<AuctionItem, AuctionDto>();
        CreateMap<AuctionCreationDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
        CreateMap<AuctionCreationDto, AuctionItem>();
        
        // Message Broker
        CreateMap<AuctionDto, AuctionCreated>();
        CreateMap<Auction, AuctionUpdated>().IncludeMembers(auction => auction.Item);
        CreateMap<AuctionItem, AuctionUpdated>();
    }
}
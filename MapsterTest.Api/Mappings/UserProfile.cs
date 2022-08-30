using AutoMapper;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Models;

namespace MapsterTest.Api.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponse>().ReverseMap();
    }    
}
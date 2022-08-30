using MapsterTest.Api.Dto;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByAutoMapper;

public record GetAllUsersByAutoMapperQuery : IRequest<IEnumerable<UserResponse>>
{
    
}
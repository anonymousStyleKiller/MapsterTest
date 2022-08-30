using MapsterTest.Api.Dto;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAll;

public record GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
{
    
}
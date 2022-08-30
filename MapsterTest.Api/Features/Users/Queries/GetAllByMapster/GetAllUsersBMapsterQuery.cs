using MapsterTest.Api.Dto;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByMapster;

public record GetAllUsersBMapsterQuery: IRequest<IEnumerable<UserResponse>>
{
    
}

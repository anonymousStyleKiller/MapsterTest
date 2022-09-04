using MapsterTest.Api.Dto;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByDapper;

public class GetAllByDapperQuery : IRequest<IEnumerable<UserResponse>>
{
}
using MapsterTest.Api.Dto;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByAutoMapperWitDapper;

public class GetAllByAutoMapperWitDapperQuery : IRequest<IEnumerable<UserResponse>>
{
}
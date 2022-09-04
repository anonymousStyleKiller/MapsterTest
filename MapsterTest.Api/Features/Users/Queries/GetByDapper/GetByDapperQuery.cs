using MapsterTest.Api.Dto;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetByDapper;

public class GetByDapperQuery : IRequest<UserResponse>
{
    public GetByDapperQuery(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}
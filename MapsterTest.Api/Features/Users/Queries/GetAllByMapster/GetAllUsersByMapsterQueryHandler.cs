using Mapster;
using MapsterMapper;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Models;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByMapster;

public record GetAllUsersByMapsterQueryHandler : IRequestHandler<GetAllUsersBMapsterQuery, IEnumerable<UserResponse>>
{
    private readonly IRepositoryAsync<User> _repositoryAsync;
    

    public GetAllUsersByMapsterQueryHandler(IRepositoryAsync<User> repositoryAsync)
    {
        _repositoryAsync = repositoryAsync;
      
    }

    public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersBMapsterQuery request, CancellationToken cancellationToken)
    {
        var users = await _repositoryAsync.GetAllAsync().ConfigureAwait(false);
        return users.Adapt<IEnumerable<UserResponse>>();
    }
}
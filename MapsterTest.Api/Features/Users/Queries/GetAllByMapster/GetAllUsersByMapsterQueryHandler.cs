using Mapster;
using MapsterMapper;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Models;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByMapster;

public record GetAllUsersByMapsterQueryHandler : IRequestHandler<GetAllUsersBMapsterQuery, IEnumerable<UserResponse>>
{
    private readonly IRepository<User> _repository;
    
    public GetAllUsersByMapsterQueryHandler(IRepository<User> repository)
    {
        _repository = repository;
      
    }

    public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersBMapsterQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync().ConfigureAwait(false);
        return users.AsQueryable().ProjectToType<UserResponse>();
    }
}
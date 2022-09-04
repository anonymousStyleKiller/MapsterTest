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
    private readonly IMapper _mapper;
    
    public GetAllUsersByMapsterQueryHandler(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersBMapsterQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsyncByEntityFrameworkAsync().ConfigureAwait(false);
        return _mapper.From(users).AdaptToType<IEnumerable<UserResponse>>();
    }
}
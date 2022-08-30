using AutoMapper;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Mappings;
using MapsterTest.Api.Models;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAll;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
{
    private readonly IRepositoryAsync<User> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repositoryAsync.GetAllAsync().ConfigureAwait(false);
        return _mapper.Map<IList<UserResponse>>(users);
    }
}
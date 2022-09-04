using MapsterTest.Api.Dto;
using MapsterTest.Api.Interfaces;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByDapper;

public class GetAllByDapperQueryHandler : IRequestHandler<GetAllByDapperQuery, IEnumerable<UserResponse>>
{
   
    private readonly IRepository<UserResponse> _repository;

    public GetAllByDapperQueryHandler(IRepository<UserResponse> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<UserResponse>> Handle(GetAllByDapperQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsyncByDapperAsync().ConfigureAwait(false);
    }
}
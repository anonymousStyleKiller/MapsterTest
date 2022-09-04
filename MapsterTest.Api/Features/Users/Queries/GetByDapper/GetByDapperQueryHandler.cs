using MapsterTest.Api.Dto;
using MapsterTest.Api.Interfaces;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetByDapper;

public class GetByDapperQueryHandler : IRequestHandler<GetByDapperQuery, UserResponse>
{
    private readonly IRepository<UserResponse> _repository;

    public GetByDapperQueryHandler(IRepository<UserResponse> repository)
    {
        _repository = repository;
    }

    public async Task<UserResponse> Handle(GetByDapperQuery request, CancellationToken cancellationToken)
    {
         return   await _repository.GetAsyncByDapper(request.Id);
    }
}
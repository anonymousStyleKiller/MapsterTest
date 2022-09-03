using AutoMapper;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Interfaces;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByAutoMapperWitDapper;

public class GetAllByAutoMapperWitDapperQueryHandler : IRequestHandler<GetAllByAutoMapperWitDapperQuery, IEnumerable<UserResponse>>
{
   
    private readonly IRepository<UserResponse> _repository;
    private readonly IMapper _mapper;

    public GetAllByAutoMapperWitDapperQueryHandler(IRepository<UserResponse> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserResponse>> Handle(GetAllByAutoMapperWitDapperQuery request, CancellationToken cancellationToken)
    {
        var x = await _repository.GetAllAsyncByDapper().ConfigureAwait(false);
        return x;
    }
}
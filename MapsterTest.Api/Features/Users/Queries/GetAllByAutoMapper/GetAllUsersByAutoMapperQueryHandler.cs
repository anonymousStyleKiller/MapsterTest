using AutoMapper;
using MapsterTest.Api.Dto;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Models;
using MediatR;

namespace MapsterTest.Api.Features.Users.Queries.GetAllByAutoMapper;

public class GetAllUsersByAutoMapperQueryHandler : IRequestHandler<GetAllUsersByAutoMapperQuery, IEnumerable<UserResponse>>
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;

    public GetAllUsersByAutoMapperQueryHandler(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersByAutoMapperQuery request, CancellationToken cancellationToken)
    {
      return _mapper.Map<IEnumerable<UserResponse>>(await _repository.GetAllAsyncByEntityFrameworkAsync().ConfigureAwait(false));
    }
}
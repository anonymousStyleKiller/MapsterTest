using System.Net.Http.Json;
using MapsterTest.Api.Dto;

namespace MapsterTest.ConsoleUI.Mock;

public class MockCient
{ 
    
    private readonly HttpClient _client;

    public MockCient(HttpClient Client)
    {
        _client = Client;
    }
    
    public async Task<IEnumerable<UserResponse>?> GetInfoByAutoMapper(CancellationToken cancel = default)
    {
      return  await _client
            .GetFromJsonAsync<IEnumerable<UserResponse>>("/byAutoMapper", cancel)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<UserResponse>?> GetInfoByMappster(CancellationToken cancel = default)
    {
        return await _client
                   .GetFromJsonAsync<IEnumerable<UserResponse>>("/byMapster", cancel)
                   .ConfigureAwait(false);
    }
}
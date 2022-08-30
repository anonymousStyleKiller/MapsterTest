using MapsterTest.Api.Contexts;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Models;

namespace MapsterTest.Api.Mock;

public class DbService : IDbService
{
    private readonly BaseContext _db;
    private readonly IRepositoryAsync<User> _repositoryAsync;

    public DbService(BaseContext db, IRepositoryAsync<User> repositoryAsync)
    {
        _db = db;
        _repositoryAsync = repositoryAsync;
    }

    public void Init()
    {
        for (var i = 0; i < 100; i++) AddUsers(i);
        _db.SaveChanges();
    }

    private void AddUsers(int i)
    {
        Task.Run(async () =>
        {
            var newUser = new User
            {
             Id=new Guid(),
             Address = $"Address {i}",
             City = $"City {i}",
             Country = $"Country {i}",
             CreatedOn = DateTime.Now,
             FirstName = $"Name {i}",
             LastName = $"Last Name {i}"
            };
            await _repositoryAsync.AddAsync(newUser).ConfigureAwait(false);
        }, CancellationToken.None).GetAwaiter().GetResult();
    }
}
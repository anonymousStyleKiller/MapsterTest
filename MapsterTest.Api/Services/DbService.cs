using MapsterTest.Api.Contexts;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Models;

namespace MapsterTest.Api.Services;

public class DbService : IDbService
{
    private readonly BaseContext _db;
    private readonly IRepository<User> _repository;

    public DbService(BaseContext db, IRepository<User> repository)
    {
        _db = db;
        _repository = repository;
    }

    public void Init()
    {
        ClearData(GetAllData());

        for (var i = 0; i < 10000; i++)
        {
            AddUsers(i);
        }

        _db.SaveChanges();
    }

    private async Task<IEnumerable<User>> GetAllData()
    {
        return await _repository.GetAllAsync();
    }

    private void AddUsers(int i)
    {
        Task.Run(async () =>
        {
            var newUser = new User
            {
                Id = new Guid(),
                Address = $"Address {i}",
                City = $"City {i}",
                Country = $"Country {i}",
                CreatedOn = DateTime.Now,
                FirstName = $"Name {i}",
                LastName = $"Last Name {i}"
            };
            await _repository.AddAsync(newUser).ConfigureAwait(false);
        }, CancellationToken.None).GetAwaiter().GetResult();
    }

    private void ClearData(Task<IEnumerable<User>> getAllData)
    {
        _repository.Delete(getAllData.Result);
    }
}
using MapsterTest.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapsterTest.Api.Repository;

public class RepositoryAsync<T> : IRepositoryAsync<T> where T: class
{
    private readonly Contexts.BaseContext _dbContext;

    public RepositoryAsync(Contexts.BaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<T> Entities => _dbContext.Set<T>();
    
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public void Delete(IEnumerable<T> entity)
    {
        _dbContext
            .Set<T>()
            .RemoveRange(entity);
        _dbContext.SaveChanges();
    }
}
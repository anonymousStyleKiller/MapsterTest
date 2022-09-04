using Dapper;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MapsterTest.Api.Repository;

public class Repository<T> : IRepository<T> where T: class
{
    private readonly Contexts.BaseContext _dbContext;
    private readonly IConfiguration _configuration;
    public Repository(Contexts.BaseContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }
    public IQueryable<T> Entities => _dbContext.Set<T>();
    
    public async Task<IEnumerable<T>> GetAllAsyncByEntityFrameworkAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsyncByDapperAsync()
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        return await connection.QueryAsync<T>("select * from users");
    }

    public async Task<T> GetAsyncByDapper(string id)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        return await connection.QueryFirstAsync<T>("select * from users where Id = @Id", new{ id});
    }

    public async Task<T> AddAsyncByEntityFramework(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public void DeleteByEntityFramework(IEnumerable<T> entity)
    {
        _dbContext
            .Set<T>()
            .RemoveRange(entity);
        _dbContext.SaveChanges();
    }
}
namespace MapsterTest.Api.Interfaces;

public interface IRepositoryAsync<T> where T : class
{
    public  Task<List<T>> GetAllAsync();
    public Task<T> AddAsync(T entity);
    public void Delete(IEnumerable<T> entity);
}
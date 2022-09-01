namespace MapsterTest.Api.Interfaces;

public interface IRepository<T> where T : class
{
    public  Task<IEnumerable<T>> GetAllAsync();
    public Task<T> AddAsync(T entity);
    public void Delete(IEnumerable<T> entity);
}
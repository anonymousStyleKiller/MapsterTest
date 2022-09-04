namespace MapsterTest.Api.Interfaces;

public interface IRepository<T> where T : class
{
    public  Task<IEnumerable<T>> GetAllAsyncByEntityFrameworkAsync();
    public  Task<IEnumerable<T>> GetAllAsyncByDapperAsync();
    public  Task<T> GetAsyncByDapper(string id);
    public Task<T> AddAsyncByEntityFramework(T entity);
    public void DeleteByEntityFramework(IEnumerable<T> entity);
}
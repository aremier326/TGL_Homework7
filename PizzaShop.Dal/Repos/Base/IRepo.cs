namespace PizzaShop.Dal.Repos.Base
{
    public interface IRepo<T> : IDisposable
    {
        Task<int> AddAsync(T entity, bool persist = true);
        Task<int> UpdateAsync(T entity, bool persist = true);
        Task<int> DeleteAsync(T entity, bool persist = true);
        Task<T> FindAsync(int? id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}

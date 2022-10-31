namespace PHCleanArchSample.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<T> GetByIdAsync(int id);

        public Task<T> CreateAsync(T entity);

        public Task<T> UpdateAsync(T entity);

        public Task<bool> DeleteAsync(int id);
    }
}

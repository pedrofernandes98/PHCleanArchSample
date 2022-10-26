using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHCleanArchSample.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetByIdAsync(int id);

        public Task<T> CreateAsync(T entity);

        public Task<T> UpdateAsync(T entity);

        public Task<bool> DeleteAsync(int id);
    }
}

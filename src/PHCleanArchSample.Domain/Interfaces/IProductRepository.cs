using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
    }
}

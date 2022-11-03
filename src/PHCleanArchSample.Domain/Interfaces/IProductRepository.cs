using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<Product> GetProductsAndCategory(int id);
    }
}

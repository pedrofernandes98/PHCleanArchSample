using PHCleanArchSample.Application.Dtos;

namespace PHCleanArchSample.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        
        Task<ProductDto> GetProductsById(int? id);

        Task<ProductDto> Update(ProductDto productDto);

        Task<ProductDto> Add(ProductDto productDto);

        Task<bool> Remove(int? id);

        public Task<ProductDto> GetProductsAndCategory(int id);
    }
}
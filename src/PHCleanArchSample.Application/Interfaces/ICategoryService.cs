using PHCleanArchSample.Application.Dtos;

namespace PHCleanArchSample.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        
        Task<CategoryDto> GetCategoryById(int? id);

        Task<CategoryDto> Update(CategoryDto categoryDto);

        Task<CategoryDto> Add(CategoryDto categoryDto);

        Task<bool> Remove(int? id);
    }
}
using AutoMapper;
using PHCleanArchSample.Application.Dtos;
using PHCleanArchSample.Application.Interfaces;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;


        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Add(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            var newCategory = await _repository.CreateAsync(categoryEntity);
            return _mapper.Map<CategoryDto>(newCategory);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _repository.GetAllAsync());
        }

        public async Task<CategoryDto> GetCategoryById(int? id)
        {
            return _mapper.Map<CategoryDto>(await _repository.GetByIdAsync(Convert.ToInt32(id))); 
        }

        public async Task<bool> Remove(int? id)
        {
            var entityToRemove = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if(entityToRemove != null){
                return await _repository.DeleteAsync(Convert.ToInt32(id));
            }

            return false;
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            var changedCategory = await _repository.UpdateAsync(categoryEntity);
            return _mapper.Map<CategoryDto>(changedCategory);
        }
    }
    

    
}
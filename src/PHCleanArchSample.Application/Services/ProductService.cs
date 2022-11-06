using AutoMapper;
using PHCleanArchSample.Application.Dtos;
using PHCleanArchSample.Application.Interfaces;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;


        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = _mapper;
        }

        public async Task<ProductDto> Add(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            var newProduct = await _repository.CreateAsync(productEntity);
            return _mapper.Map<ProductDto>(newProduct);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _repository.GetAllAsync());
        }

        public async Task<ProductDto> GetProductsById(int? id)
        {
            return _mapper.Map<ProductDto>(await _repository.GetByIdAsync(Convert.ToInt32(id))); 
        }

        public async Task<bool> Remove(int? id)
        {
            var entityToRemove = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if(entityToRemove != null){
                return await _repository.DeleteAsync(Convert.ToInt32(id));
            }

            return false;
        }

        public async Task<ProductDto> Update(ProductDto ProductDto)
        {
            var productEntity = _mapper.Map<Product>(ProductDto);
            var changedProduct = await _repository.UpdateAsync(productEntity);
            return _mapper.Map<ProductDto>(changedProduct);
        }

        public async Task<ProductDto> GetProductsAndCategory(int id)
        {
            return _mapper.Map<ProductDto>(await _repository.GetProductsAndCategory(Convert.ToInt32(id))); 
        }
    }
    

    
}
using AutoMapper;
using MediatR;
using PHCleanArchSample.Application.Commands;
using PHCleanArchSample.Application.Dtos;
using PHCleanArchSample.Application.Interfaces;
using PHCleanArchSample.Application.Querys;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductDto> Add(ProductDto productDto)
        {
            var createProductCommand = _mapper.Map<CreateProductCommand>(productDto);
            var newProduct = await _mediator.Send(createProductCommand);
            return _mapper.Map<ProductDto>(newProduct);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var getProductsQuery = new GetProductsQuery();

            if(getProductsQuery == null)
                throw new ArgumentNullException(nameof(getProductsQuery));

            return _mapper.Map<IEnumerable<ProductDto>>(await _mediator.Send(getProductsQuery));
        }

        public async Task<ProductDto> GetProductsById(int? id)
        {
            var getProductsByIdQuery = new GetProductByIdQuery();
            
            if (id != null)
                getProductsByIdQuery.Id = id.Value;

            if (getProductsByIdQuery == null)
                throw new ArgumentNullException(nameof(getProductsByIdQuery));

            return _mapper.Map<ProductDto>(await _mediator.Send(getProductsByIdQuery));
        }

        public async Task<bool> Remove(int? id)
        {
            var removeProductCommand = new RemoveProductCommand();
            
            if (id != null)
                removeProductCommand.Id = id.Value;

            if(removeProductCommand != null)
                return await _mediator.Send(removeProductCommand);
            
            return false;
        }

        public async Task<ProductDto> Update(ProductDto ProductDto)
        {
            var updateProductCommand = _mapper.Map<UpdateProductCommand>(ProductDto);

            if (updateProductCommand == null)
                throw new ArgumentNullException(nameof(updateProductCommand));

            var changedProduct = await _mediator.Send(updateProductCommand);

            return _mapper.Map<ProductDto>(changedProduct);
        }
    }
    

    
}
using MediatR;
using PHCleanArchSample.Application.Commands;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product == null)
                throw new ApplicationException("Erro ao criar um novo produto.");

            return await _repository.CreateAsync(product);
        }
    }
}

using MediatR;
using PHCleanArchSample.Application.Commands;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request?.Id != 0)
                throw new ApplicationException("Não foi informado o Id do recurso que deseja-se atualizar");

            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException("Erro ao criar um novo produto.");

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image);

            return await _repository.UpdateAsync(product);
        }
    }
}

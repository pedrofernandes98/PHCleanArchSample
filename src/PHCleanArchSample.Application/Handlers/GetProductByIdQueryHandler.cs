using MediatR;
using PHCleanArchSample.Application.Querys;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (request?.Id != 0)
                throw new ApplicationException("Não foi informado o Id do recurso que deseja-se atualizar");

            return await _repository.GetByIdAsync(request.Id);
        }
    }
}

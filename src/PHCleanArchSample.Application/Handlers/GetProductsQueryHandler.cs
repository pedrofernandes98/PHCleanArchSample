using MediatR;
using PHCleanArchSample.Application.Querys;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

using MediatR;
using PHCleanArchSample.Application.Commands;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;

namespace PHCleanArchSample.Application.Handlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public RemoveProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            if (request?.Id != 0)
                throw new ApplicationException("Não foi informado o Id do recurso que deseja-se atualizar");

            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException(string.Format("O produto de Id {0} não foi encontrado na base de dados", request.Id));
            
            return await _repository.DeleteAsync(request.Id);
        }
    }
}

using MediatR;
using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Application.Querys
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}

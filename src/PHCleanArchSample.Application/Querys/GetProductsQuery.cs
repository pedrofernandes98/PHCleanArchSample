using MediatR;
using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Application.Querys
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}

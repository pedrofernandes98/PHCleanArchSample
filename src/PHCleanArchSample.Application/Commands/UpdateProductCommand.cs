using MediatR;

namespace PHCleanArchSample.Application.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}

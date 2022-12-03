using MediatR;

namespace PHCleanArchSample.Application.Commands
{
    public class RemoveProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

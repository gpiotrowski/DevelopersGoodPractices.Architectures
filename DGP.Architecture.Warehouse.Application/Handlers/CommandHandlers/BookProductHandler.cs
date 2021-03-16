using System.Threading;
using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Commands;
using DGP.Architecture.Warehouse.Common.Handlers;
using MediatR;

namespace DGP.Architecture.Warehouse.Application.Handlers.CommandHandlers
{
    public class BookProductHandler : ICommandHandler<BookProduct>
    {
        public Task<Unit> Handle(BookProduct request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}

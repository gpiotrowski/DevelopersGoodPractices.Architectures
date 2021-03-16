using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Common.Types;
using MediatR;

namespace DGP.Architecture.Warehouse.Common.Handlers
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {

    }
}

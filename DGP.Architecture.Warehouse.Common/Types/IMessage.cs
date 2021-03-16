using MediatR;

namespace DGP.Architecture.Warehouse.Common.Types
{
    public interface IMessage : IRequest
    {
    }

    public interface IMessage<T> : IRequest<T>
    {

    }
}

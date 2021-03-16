using DGP.Architecture.Warehouse.Common.Types;
using MediatR;

namespace DGP.Architecture.Warehouse.Common.Handlers
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {
    }
}

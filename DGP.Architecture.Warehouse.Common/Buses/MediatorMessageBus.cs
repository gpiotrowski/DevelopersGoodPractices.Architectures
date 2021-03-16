using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Common.Types;
using MediatR;

namespace DGP.Architecture.Warehouse.Common.Buses
{
    public class MediatorMessageBus : IMessageBus
    {
        private readonly IMediator _mediator;

        public MediatorMessageBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Send(ICommand message)
        {
            return _mediator.Send(message);
        }

        public Task<T> Query<T>(IQuery<T> message)
        {
            return _mediator.Send(message);
        }

        public Task Publish(IEvent @event)
        {
            return _mediator.Publish(@event);
        }
    }
}
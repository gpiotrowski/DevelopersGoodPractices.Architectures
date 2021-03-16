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

        public Task Send(IMessage message)
        {
            return _mediator.Send(message);
        }

        public Task<T> Query<T>(IMessage<T> message)
        {
            return _mediator.Send(message);
        }
    }
}
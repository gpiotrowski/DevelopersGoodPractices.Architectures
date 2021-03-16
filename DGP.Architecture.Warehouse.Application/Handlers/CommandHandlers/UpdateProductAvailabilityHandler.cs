using System.Threading;
using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Commands;
using DGP.Architecture.Warehouse.Application.Events;
using DGP.Architecture.Warehouse.Common.Buses;
using DGP.Architecture.Warehouse.Common.Handlers;
using DGP.Architecture.Warehouse.Infrastructure.Repositories;
using MediatR;

namespace DGP.Architecture.Warehouse.Application.Handlers.CommandHandlers
{
    public class UpdateProductAvailabilityHandler : ICommandHandler<UpdateProductAvailability>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMessageBus _messageBus;

        public UpdateProductAvailabilityHandler(IProductRepository productRepository, IMessageBus messageBus)
        {
            _productRepository = productRepository;
            _messageBus = messageBus;
        }

        public Task<Unit> Handle(UpdateProductAvailability request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Get(request.ProductId);

            product.SetAvailability(request.AvailableQuantity);

            _messageBus.Publish(ProductAvailabilityUpdated.Create(request.ProductId, request.AvailableQuantity));

            _productRepository.Update(product);

            return Unit.Task;
        }
    }
}

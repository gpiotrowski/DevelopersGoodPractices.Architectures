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
    public class BookProductHandler : ICommandHandler<BookProduct>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMessageBus _messageBus;

        public BookProductHandler(IProductRepository productRepository, IMessageBus messageBus)
        {
            _productRepository = productRepository;
            _messageBus = messageBus;
        }

        public async Task<Unit> Handle(BookProduct request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Get(request.ProductId);

            product.DecreaseAvailability();

            _productRepository.Update(product);

            await _messageBus.Publish(ProductAvailabilityDecreased.Create(request.ProductId));

            return Unit.Value;
        }
    }
}

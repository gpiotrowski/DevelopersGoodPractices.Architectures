using System.Threading;
using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Events;
using DGP.Architecture.Warehouse.Common.Handlers;
using DGP.Architecture.Warehouse.Infrastructure.ReadModels;
using DGP.Architecture.Warehouse.Infrastructure.Repositories;

namespace DGP.Architecture.Warehouse.Application.Handlers.ReadModelBuilders
{
    public class ProductsAvailabilityReportReadModelProjection : 
        IEventHandler<ProductAvailabilityDecreased>,
        IEventHandler<ProductAvailabilityUpdated>
    {
        private readonly IProductsAvailabilityReportReadModelRepository _readModelRepository;

        public ProductsAvailabilityReportReadModelProjection(IProductsAvailabilityReportReadModelRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public async Task Handle(ProductAvailabilityDecreased notification, CancellationToken cancellationToken)
        {
            var readModel = _readModelRepository.Get(notification.ProductId);

            readModel.AvailableQuantity -= 1;

            _readModelRepository.Update(readModel);
        }

        public async Task Handle(ProductAvailabilityUpdated notification, CancellationToken cancellationToken)
        {
            var readModel = _readModelRepository.Get(notification.ProductId);

            if (readModel == null)
            {
                readModel = new ProductAvailabilityReportReadModel()
                {
                    ProductId = notification.ProductId,
                    ProductName = $"Product-{notification.ProductId}",
                    AvailableQuantity = notification.AvailableQuantity,
                    MaxAtStock = notification.AvailableQuantity
                };
            }

            readModel.AvailableQuantity = notification.AvailableQuantity;

            if (readModel.MaxAtStock < notification.AvailableQuantity)
            {
                readModel.MaxAtStock = notification.AvailableQuantity;
            }

            _readModelRepository.Update(readModel);
        }
    }
}

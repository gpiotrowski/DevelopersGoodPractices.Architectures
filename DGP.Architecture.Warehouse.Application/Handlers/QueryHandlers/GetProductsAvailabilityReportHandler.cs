using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Dtos;
using DGP.Architecture.Warehouse.Application.Queries;
using DGP.Architecture.Warehouse.Common.Handlers;
using DGP.Architecture.Warehouse.Infrastructure.Repositories;

namespace DGP.Architecture.Warehouse.Application.Handlers.QueryHandlers
{
    public class GetProductsAvailabilityReportHandler : IQueryHandler<GetProductsAvailabilityReport, ProductAvailabilityReportDto>
    {
        private readonly IProductsAvailabilityReportReadModelRepository _productsAvailabilityReportReadModelRepository;

        public GetProductsAvailabilityReportHandler(IProductsAvailabilityReportReadModelRepository productsAvailabilityReportReadModelRepository)
        {
            _productsAvailabilityReportReadModelRepository = productsAvailabilityReportReadModelRepository;
        }

        public async Task<ProductAvailabilityReportDto> Handle(GetProductsAvailabilityReport request, CancellationToken cancellationToken)
        {
            var productsAvailabilityReportReadModels = _productsAvailabilityReportReadModelRepository.GetAll();

            return new ProductAvailabilityReportDto()
            {
                ProductsAvailability = productsAvailabilityReportReadModels.Select(x =>
                    new ProductAvailabilityReportDto.ProductAvailability()
                    {
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        AvailableQuantity = x.AvailableQuantity,
                        MaxAtStock = x.MaxAtStock
                    }).ToList()
            };
        }
    }
}

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Dtos;
using DGP.Architecture.Warehouse.Application.Queries;
using DGP.Architecture.Warehouse.Application.Services;
using DGP.Architecture.Warehouse.Common.Handlers;
using DGP.Architecture.Warehouse.Infrastructure.Repositories;

namespace DGP.Architecture.Warehouse.Application.Handlers.QueryHandlers
{
    public class GetProductsAvailabilityReportHandler : IQueryHandler<GetProductsAvailabilityReport, ProductAvailabilityReportDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductStockHistoryService _productStockHistoryService;

        public GetProductsAvailabilityReportHandler(IProductRepository productRepository, IProductStockHistoryService productStockHistoryService)
        {
            _productRepository = productRepository;
            _productStockHistoryService = productStockHistoryService;
        }

        public async Task<ProductAvailabilityReportDto> Handle(GetProductsAvailabilityReport request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll();

            var report = new ProductAvailabilityReportDto()
            {
                ProductsAvailability = products
                    .Select(x => new ProductAvailabilityReportDto.ProductAvailability()
                    {
                        ProductId = x.Id,
                        ProductName = $"Product-{x.Id}",
                        AvailableQuantity = x.AvailableQuantity,
                        MaxAtStock = _productStockHistoryService.GetStockHistory(x.Id).StockHistory
                            .Max(sh => sh.AvailableQuantity)
                    }).ToList()
            };

            return report;
        }
    }
}

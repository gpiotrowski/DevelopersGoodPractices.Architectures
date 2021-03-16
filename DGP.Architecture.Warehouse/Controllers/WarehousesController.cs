using System.Linq;
using DGP.Architecture.Warehouse.Dtos;
using DGP.Architecture.Warehouse.Repositories;
using DGP.Architecture.Warehouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGP.Architecture.Warehouse.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductStockHistoryService _productStockHistoryService;

        public WarehousesController(IProductRepository productRepository, IProductStockHistoryService productStockHistoryService)
        {
            _productRepository = productRepository;
            _productStockHistoryService = productStockHistoryService;
        }

        [HttpPost("products/{productId}/reservations")]
        public void BookProducts(BookProductDto bookProductDto)
        {
            var product = _productRepository.Get(bookProductDto.ProductId);

            product.DecreaseAvailability();

            _productRepository.Update(product);
        }

        [HttpPut("products/{productId}/availability")]
        public void UpdateProductAvailability(UpdateProductAvailabilityDto updateProductAvailabilityDto)
        {
            var product = _productRepository.Get(updateProductAvailabilityDto.ProductId);

            product.SetAvailability(updateProductAvailabilityDto.AvailableQuantity);

            _productRepository.Update(product);

        }

        [HttpGet("products/{productId}/availability")]
        public ProductAvailabilityDto GetProductAvailability(int productId)
        {
            var product = _productRepository.Get(productId);

            var productAvailabilityDto = new ProductAvailabilityDto()
            {
                ProductId = product.Id,
                AvailableQuantity = product.AvailableQuantity
            };

            return productAvailabilityDto;
        }

        [HttpGet("products/availability")]
        public ProductAvailabilityReportDto GetProductAvailabilityReport()
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

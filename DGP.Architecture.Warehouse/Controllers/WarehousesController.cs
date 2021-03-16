using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Commands;
using DGP.Architecture.Warehouse.Application.Dtos;
using DGP.Architecture.Warehouse.Application.Queries;
using DGP.Architecture.Warehouse.Common.Buses;
using Microsoft.AspNetCore.Mvc;

namespace DGP.Architecture.Warehouse.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public WarehousesController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [HttpPost("products/{productId}/reservations")]
        public async Task BookProducts(BookProduct command)
        {
            await _messageBus.Send(command);
        }

        [HttpPut("products/{productId}/availability")]
        public async Task UpdateProductAvailability(UpdateProductAvailability command)
        {
            await _messageBus.Send(command);

        }

        [HttpGet("products/{productId}/availability")]
        public async Task<ProductAvailabilityDto> GetProductAvailability([FromQuery] GetProductAvailability query)
        {
            return await _messageBus.Query(query);
        }

        [HttpGet("products/availability")]
        public async Task<ProductAvailabilityReportDto> GetProductAvailabilityReport([FromQuery] GetProductsAvailabilityReport query)
        {
            return await _messageBus.Query(query);
        }
    }
}

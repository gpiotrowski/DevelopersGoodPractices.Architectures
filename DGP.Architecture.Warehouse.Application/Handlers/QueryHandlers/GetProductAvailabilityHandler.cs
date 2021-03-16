using System.Threading;
using System.Threading.Tasks;
using DGP.Architecture.Warehouse.Application.Dtos;
using DGP.Architecture.Warehouse.Application.Queries;
using DGP.Architecture.Warehouse.Common.Handlers;
using DGP.Architecture.Warehouse.Infrastructure.Repositories;

namespace DGP.Architecture.Warehouse.Application.Handlers.QueryHandlers
{
    public class GetProductAvailabilityHandler : IQueryHandler<GetProductAvailability, ProductAvailabilityDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductAvailabilityHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductAvailabilityDto> Handle(GetProductAvailability request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Get(request.ProductId);

            var productAvailabilityDto = new ProductAvailabilityDto()
            {
                ProductId = product.Id,
                AvailableQuantity = product.AvailableQuantity
            };

            return productAvailabilityDto;
        }
    }
}

using DGP.Architecture.Warehouse.Application.Dtos;
using DGP.Architecture.Warehouse.Common.Types;

namespace DGP.Architecture.Warehouse.Application.Queries
{
    public class GetProductAvailability : IQuery<ProductAvailabilityDto>
    {
        public int ProductId { get; set; }
    }
}

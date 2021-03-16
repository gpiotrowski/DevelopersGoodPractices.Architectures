using DGP.Architecture.Warehouse.Common.Types;

namespace DGP.Architecture.Warehouse.Application.Events
{
    public class ProductAvailabilityDecreased : IEvent
    {
        public int ProductId { get; set; }

        public static ProductAvailabilityDecreased Create(int productId)
        {
            return new ProductAvailabilityDecreased()
            {
                ProductId = productId
            };
        }
    }
}
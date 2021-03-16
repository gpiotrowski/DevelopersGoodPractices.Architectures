using DGP.Architecture.Warehouse.Common.Types;

namespace DGP.Architecture.Warehouse.Application.Events
{
    public class ProductAvailabilityUpdated : IEvent
    {
        public int ProductId { get; set; }
        public int AvailableQuantity { get; set; }

        public static ProductAvailabilityUpdated Create(int productId, int availableQuantity)
        {
            return new ProductAvailabilityUpdated()
            {
                ProductId = productId,
                AvailableQuantity = availableQuantity
            };
        }
    }
}

using System.Collections.Generic;

namespace DGP.Architecture.Warehouse.Dtos
{
    public class ProductAvailabilityReportDto
    {
        public List<ProductAvailability> ProductsAvailability { get; set; }

        public class ProductAvailability
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int AvailableQuantity { get; set; }
            public int MaxAtStock { get; set; }
        }
    }
}
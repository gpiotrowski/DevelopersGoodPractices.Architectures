namespace DGP.Architecture.Warehouse.Infrastructure.ReadModels
{
    public class ProductAvailabilityReportReadModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int AvailableQuantity { get; set; }
        public int MaxAtStock { get; set; }
    }
}

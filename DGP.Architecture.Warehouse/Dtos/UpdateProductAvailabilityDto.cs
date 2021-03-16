namespace DGP.Architecture.Warehouse.Dtos
{
    public class UpdateProductAvailabilityDto
    {
        public int ProductId { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
namespace DGP.Architecture.Warehouse.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }

        public void DecreaseAvailability()
        {
            AvailableQuantity--;
        }

        public void SetAvailability(int availableQuantity)
        {
            AvailableQuantity = availableQuantity;
        }
    }
}
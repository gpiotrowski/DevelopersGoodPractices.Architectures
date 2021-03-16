using System.Collections.Generic;

namespace DGP.Architecture.Orders.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<int> Products { get; set; }

        public Cart()
        {
            Products = new List<int>();
        }

        public void AddProduct(int productId)
        {
            Products.Add(productId);
        }

        public void RemoveProduct(int productId)
        {
            Products.Remove(productId);
        }
    }
}
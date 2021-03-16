using System;
using System.Collections.Generic;

namespace DGP.Architecture.Orders.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<int> ProductsIds { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal DeliveryCost { get; set; }
    }
}
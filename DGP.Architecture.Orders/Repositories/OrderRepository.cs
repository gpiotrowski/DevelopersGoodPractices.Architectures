using System.Collections.Generic;
using DGP.Architecture.Orders.Models;

namespace DGP.Architecture.Orders.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        public void Add(Order order)
        {
            _orders.Add(order);
        }
    }
}
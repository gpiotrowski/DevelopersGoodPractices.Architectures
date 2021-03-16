using System.Collections.Generic;
using DGP.Architecture.Orders.Domain.Models;
using DGP.Architecture.Orders.Domain.Repositories;

namespace DGP.Architecture.Orders.Infrastructure.Repositories
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
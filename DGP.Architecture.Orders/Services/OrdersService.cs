using System;
using System.Linq;
using DGP.Architecture.Orders.Dtos;
using DGP.Architecture.Orders.ExternalSystems;
using DGP.Architecture.Orders.Models;
using DGP.Architecture.Orders.Repositories;

namespace DGP.Architecture.Orders.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICourierService _courierService;
        private readonly IOrderRepository _orderRepository;
        private readonly IWarehouseService _warehouseService;

        public OrdersService(ICartRepository cartRepository, ICourierService courierService,
            IOrderRepository orderRepository, IWarehouseService warehouseService)
        {
            _cartRepository = cartRepository;
            _courierService = courierService;
            _orderRepository = orderRepository;
            _warehouseService = warehouseService;
        }

        public void FinalizeOrder(NewOrderDto newOrder)
        {
            var cart = _cartRepository.Get(newOrder.CartId);

            _warehouseService.BookProducts(cart.Products);

            var order = new Order()
            {
                Id = Guid.NewGuid(),
                DeliveryAddress = newOrder.DeliveryAddress,
                ProductsIds = cart.Products.Select(x => x).ToList(),
                DeliveryCost = _courierService.CalculateDeliveryCost(newOrder.DeliveryAddress)
            };

            _orderRepository.Add(order);

            _courierService.ScheduleCourierService(order.Id, order.DeliveryAddress);
        }
    }
}
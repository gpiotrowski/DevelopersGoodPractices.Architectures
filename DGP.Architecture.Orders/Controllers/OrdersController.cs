﻿using DGP.Architecture.Orders.Domain.Dtos;
using DGP.Architecture.Orders.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGP.Architecture.Orders.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public void Order(NewOrderDto newOrder)
        {
            _ordersService.FinalizeOrder(newOrder);
        }
    }
}

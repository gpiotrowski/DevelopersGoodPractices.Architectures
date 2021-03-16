using System;
using DGP.Architecture.Orders.Domain.ExternalSystems;

namespace DGP.Architecture.Orders.CourierSystemAdapter
{
    public class CourierService : ICourierService
    {
        public void ScheduleCourierService(Guid transportId, string deliveryAddress)
        {
            // [...]
        }

        public decimal CalculateDeliveryCost(string deliveryAddress)
        {
            return 1.23M;
        }
    }
}
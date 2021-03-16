using System;

namespace DGP.Architecture.Orders.ExternalSystems
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
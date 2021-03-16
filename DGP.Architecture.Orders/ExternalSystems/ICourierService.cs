using System;

namespace DGP.Architecture.Orders.ExternalSystems
{
    public interface ICourierService
    {
        void ScheduleCourierService(Guid transportId, string deliveryAddress);
        decimal CalculateDeliveryCost(string deliveryAddress);
    }
}
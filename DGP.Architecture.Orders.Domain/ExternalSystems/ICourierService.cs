using System;

namespace DGP.Architecture.Orders.Domain.ExternalSystems
{
    public interface ICourierService
    {
        void ScheduleCourierService(Guid transportId, string deliveryAddress);
        decimal CalculateDeliveryCost(string deliveryAddress);
    }
}
using DGP.Architecture.Orders.Domain.Models;

namespace DGP.Architecture.Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
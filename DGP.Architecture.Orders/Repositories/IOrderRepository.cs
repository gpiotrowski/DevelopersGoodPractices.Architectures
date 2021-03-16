using DGP.Architecture.Orders.Models;

namespace DGP.Architecture.Orders.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
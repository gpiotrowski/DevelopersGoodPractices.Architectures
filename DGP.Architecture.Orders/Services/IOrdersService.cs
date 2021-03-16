using DGP.Architecture.Orders.Dtos;

namespace DGP.Architecture.Orders.Services
{
    public interface IOrdersService
    {
        void FinalizeOrder(NewOrderDto newOrder);
    }
}
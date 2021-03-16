using DGP.Architecture.Orders.Domain.Dtos;

namespace DGP.Architecture.Orders.Domain.Services
{
    public interface IOrdersService
    {
        void FinalizeOrder(NewOrderDto newOrder);
    }
}
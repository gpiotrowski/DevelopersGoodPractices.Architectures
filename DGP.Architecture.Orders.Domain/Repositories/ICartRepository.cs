using DGP.Architecture.Orders.Domain.Models;

namespace DGP.Architecture.Orders.Domain.Repositories
{
    public interface ICartRepository
    {
        void Add(Cart cart);
        void Remove(int cartId);
        int GenerateId();
        Cart Get(int cartId);
        void Update(Cart cart);
    }
}
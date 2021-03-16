using DGP.Architecture.Orders.Models;

namespace DGP.Architecture.Orders.Repositories
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
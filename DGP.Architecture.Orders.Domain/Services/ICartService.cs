using DGP.Architecture.Orders.Domain.Dtos;

namespace DGP.Architecture.Orders.Domain.Services
{
    public interface ICartService
    {
        CartDto CreateNewCart();
        void AddProductToCart(int cartId, int productId);
        void RemoveProductFromCart(int cartId, int productId);
    }
}
using DGP.Architecture.Orders.Dtos;

namespace DGP.Architecture.Orders.Services
{
    public interface ICartService
    {
        CartDto CreateNewCart();
        void AddProductToCart(int cartId, int productId);
        void RemoveProductFromCart(int cartId, int productId);
    }
}
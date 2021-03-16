using DGP.Architecture.Orders.Domain.Dtos;
using DGP.Architecture.Orders.Domain.Models;
using DGP.Architecture.Orders.Domain.Repositories;

namespace DGP.Architecture.Orders.Domain.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public CartDto CreateNewCart()
        {
            var cart = new Cart()
            {
                Id = _cartRepository.GenerateId()
            };

            _cartRepository.Add(cart);

            var cartDto = new CartDto()
            {
                Id = cart.Id
            };
            return cartDto;
        }

        public void AddProductToCart(int cartId, int productId)
        {
            var cart = _cartRepository.Get(cartId);

            cart.AddProduct(productId);

            _cartRepository.Update(cart);
        }

        public void RemoveProductFromCart(int cartId, int productId)
        {
            var cart = _cartRepository.Get(cartId);

            cart.RemoveProduct(productId);

            _cartRepository.Update(cart);
        }
    }
}
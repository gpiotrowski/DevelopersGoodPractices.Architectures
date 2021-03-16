using System.Collections.Generic;
using System.Linq;
using DGP.Architecture.Orders.Domain.Models;
using DGP.Architecture.Orders.Domain.Repositories;

namespace DGP.Architecture.Orders.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly List<Cart> _carts;

        public CartRepository()
        {
            _carts = new List<Cart>();
        }

        public int GenerateId()
        {
            return _carts.Any() ? _carts.Select(x => x.Id).Max() + 1 : 1;
        }

        public Cart Get(int cartId)
        {
            return _carts.Single(x => x.Id == cartId);
        }

        public void Add(Cart cart)
        {
            _carts.Add(cart);
        }

        public void Update(Cart cart)
        {
            // Simulate "update"
            var cartToRemove = _carts.Single(x => x.Id == cart.Id);
            _carts.Remove(cartToRemove);

            _carts.Add(cart);
        }

        public void Remove(int cartId)
        {
            var cartToRemove = _carts.Single(x => x.Id == cartId);
            _carts.Remove(cartToRemove);
        }
    }
}
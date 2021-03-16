using DGP.Architecture.Orders.Dtos;
using DGP.Architecture.Orders.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGP.Architecture.Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public CartDto CreateCart()
        {
            return _cartService.CreateNewCart();
        }

        [HttpPost("{cartId}/products")]
        public void AddProductToCart(int cartId, [FromBody] int productId)
        {
            _cartService.AddProductToCart(cartId, productId);
        }

        [HttpDelete("{cartId}/products/{productId}")]
        public void RemoveProductFromCart(int cartId, int productId)
        {
            _cartService.RemoveProductFromCart(cartId, productId);
        }
    }
}

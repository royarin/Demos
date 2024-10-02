using System.Linq.Expressions;
using CartAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using CartAPI.Services;

namespace CartAPI.Controllers
{
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService){
            _cartService = cartService;
        }

        [HttpPost("cart/add")]
        public async Task<IActionResult> AddToCart(Product product){
            await _cartService.AddToCart(product);
            return Ok();
        }

        [HttpGet("cart")]
        public async Task<IActionResult> GetCart(){
            return Ok(await _cartService.GetCart());
        }

        [HttpPost("cart/clear")]
        public async Task<IActionResult> ClearCart(){
            await _cartService.ClearCart();
            return Ok();
        }
    }
}

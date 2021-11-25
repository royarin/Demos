using System.Net;
using System.Data;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapr.Client;
using CartAPI.Models;

namespace CartAPI.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {
        private const string STATESTORE = "statestore";
        private readonly DaprClient _daprCLient;
        public CartController(DaprClient daprClient)
        {
            _daprCLient = daprClient;
        }

        [HttpPost("cart/add")]
        public async Task<IActionResult> AddToCart(Product product)
        {
            var state = await _daprCLient.GetStateEntryAsync<Cart>(STATESTORE, "cart");

            state.Value ??= new Cart()
            {
                LineItems = new List<LineItem>()
            };

            var itemExists = state.Value.LineItems.FirstOrDefault(x => x.Product.SKU == product.SKU);

            if (itemExists == null)
            {
                state.Value.LineItems.Add(new LineItem()
                {
                    Product = product,
                    Quantity = 1
                });
            }
            else
            {
                state.Value.LineItems.FirstOrDefault(x => x.Product.SKU == product.SKU).Quantity++;
            }

            await state.SaveAsync();

            return Accepted();
        }

        [HttpGet("cart")]
        public async Task<IActionResult> GetCart()
        {
            var state = await _daprCLient.GetStateEntryAsync<Cart>(STATESTORE, "cart");
            if (state.Value == null)
            {
                return NotFound();
            }

            return new OkObjectResult(state.Value);
        }

        [HttpPost("cart/remove")]
        public async void RemoveFromCart(Product product)
        {
            var state = await _daprCLient.GetStateEntryAsync<Cart>(STATESTORE, "cart");
            var currentItem = state.Value.LineItems.FirstOrDefault(x => x.Product.SKU == product.SKU);
            if (currentItem != null)
            {
                if (currentItem.Quantity == 1)
                    state.Value?.LineItems.Remove(currentItem);
                else
                {
                    state.Value.LineItems.FirstOrDefault(x => x.Product.SKU == product.SKU).Quantity--;
                }

                await state.SaveAsync();
            }
        }

        [HttpPost("cart/clear")]
        public async void ClearCart()
        {
            await _daprCLient.DeleteStateAsync(STATESTORE, "cart");
        }

    }
}

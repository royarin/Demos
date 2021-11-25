using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HealthMarketWebClient.Data;
using HealthMarketWebClient.Services;
using Microsoft.AspNetCore.Components;

namespace HealthMarketWebClient.Pages.Cart
{
    public partial class CartList
    {
        [Inject]
        public IOrderService OrderService { get; set; }
        [Inject]
        public ICartService CartService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }


        private Data.Cart _cart;
        private IList<LineItem> _items;
        private Data.Order _orderModel;


        protected override async Task OnInitializedAsync()
        {
            // Workaround for https://github.com/dotnet/aspnetcore/issues/29846
            Activity.Current = null;
            _orderModel = new Data.Order()
            {
                OrderNumber = Guid.NewGuid().ToString()
            };
            try
            {
                _cart = await CartService.GetCart();
            }
            catch (Exception ex) { }
            _items = _cart?.LineItems;
        }

        private async Task CreateOrder()
        {
            // Workaround for https://github.com/dotnet/aspnetcore/issues/29846
            Activity.Current = null;
            // Create the order
            _orderModel.LineItems = _items;
            await OrderService.SaveOrder(_orderModel);
            await CartService.ClearCart();
            NavigationManager.NavigateTo("cartfinished");
        }

        private void RemoveItem(Data.Product item)
        {
            // Workaround for https://github.com/dotnet/aspnetcore/issues/29846
            Activity.Current = null;
            CartService.RemoveFromCart(item);
        }
    }
}

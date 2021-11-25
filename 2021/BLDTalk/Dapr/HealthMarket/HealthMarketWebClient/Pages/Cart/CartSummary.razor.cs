using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthMarketWebClient.Services;
using Microsoft.AspNetCore.Components;

namespace HealthMarketWebClient.Pages.Cart
{
    public partial class CartSummary
    {
        [Inject]
        public ICartService CartService { get; set; }

        private int ItemCount { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Workaround for https://github.com/dotnet/aspnetcore/issues/29846
            Activity.Current = null;
            var service = CartService as CartService;
            Data.Cart cart = null;
            try
            {
                cart = await CartService.GetCart();
            }
            catch (Exception ex)
            {

            }
            ItemCount = cart == null ? 0 : cart.LineItems.Sum(x => x.Quantity);

            if (service != null)
            {
                service.CartHasChangedEvent -= Service_CartHasChangedEvent;
                service.CartHasChangedEvent += Service_CartHasChangedEvent;
            }

        }

        private async void Service_CartHasChangedEvent()
        {
            // Workaround for https://github.com/dotnet/aspnetcore/issues/29846
            Activity.Current = null;
            Data.Cart cart = null;
            try
            {
                cart = await CartService.GetCart();
            }
            catch (Exception ex)
            {

            }
            ItemCount = cart == null ? 0 : cart.LineItems.Sum(x => x.Quantity);
            await InvokeAsync(() => this.StateHasChanged());
        }
    }
}

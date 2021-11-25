using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HealthMarketWebClient.Services;
using Microsoft.AspNetCore.Components;

namespace HealthMarketWebClient.Pages.Order
{
    public partial class OrderList
    {
        [Inject]
        public IOrderService OrderService { get; set; }

        private IEnumerable<Data.Order> _orders;

        protected override async Task OnInitializedAsync()
        {
            // Workaround for https://github.com/dotnet/aspnetcore/issues/29846
            Activity.Current = null;
        }

        private async Task UpdateList()
        {
            // Workaround for https://github.com/dotnet/aspnetcore/issues/29846
            Activity.Current = null;
            // _orders = await OrderService.GetOrders();
        }
    }
}

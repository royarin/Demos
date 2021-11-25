using Microsoft.AspNetCore.Components;

namespace HealthMarketWebClient.Pages.Order
{
    public partial class OrderDetail
    {
        [Parameter]
        public Data.Order Instance { get; set; }

    }
}

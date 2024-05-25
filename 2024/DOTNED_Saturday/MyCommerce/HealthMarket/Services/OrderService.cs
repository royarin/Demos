using HealthMarket.Data;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace HealthMarket.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient = null!;

        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OrderAPI");
        }

        public Order GetNewOrder()
        {
            return new Order
            {
                OrderNumber = Guid.NewGuid().ToString(),
                DeliveryCountry = "Netherlands"
            };
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await Task.Delay(100);
            return order;
        }
    }
}

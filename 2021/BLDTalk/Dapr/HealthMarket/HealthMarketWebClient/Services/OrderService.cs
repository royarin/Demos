using Dapr.Client;
using HealthMarketWebClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMarketWebClient.Services
{
    public class OrderService : IOrderService
    {
        private readonly DaprClient _daprClient;
        public OrderService(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public Order GetNewOrder()
        {
            var newOrder = new Order
            {
                DeliveryCountry = "Netherlands"
            };
            return newOrder;
        }

        public async Task SaveOrder(Order order)
        {
            await _daprClient.InvokeMethodAsync<Order>("order-api", "orders", order);
            // await _daprClient.PublishEventAsync<Order>("pubsub", "order-created", order);
        }
    }
}

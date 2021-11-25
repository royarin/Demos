using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationAPI.Models;

namespace NotificationAPI.Controllers
{
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly DaprClient _daprClient;

        public NotificationController(ILogger<NotificationController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }


        [Topic("pubsub", "order-created")]
        [HttpPost("SendNotification")]
        public async Task<IActionResult> Notify(Order order)
        {
            Console.WriteLine($"Received Order Created message for notification. Order Number : {order.OrderNumber}");
            await _daprClient.InvokeBindingAsync("sendgrid", "create", 
            $"We received your order. <br/> Your Order Number is {order.OrderNumber}.<br/> Number of items: {order.LineItems.Count}", 
            new Dictionary<string, string>(){
                {
                    "emailTo",
                    "customer@daprdemo.com"
                },
                {
                    "emailFrom",
                    "noreply@healthmarketdemo.com"
                },
                {
                    "subject",
                    "Order Confirmation"
                }
            });

            Console.WriteLine("Notification Sent");
            return Accepted();
        }
    }
}

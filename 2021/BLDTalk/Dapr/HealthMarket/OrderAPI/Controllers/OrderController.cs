using System.Security.Cryptography;
using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Dapr.Client;

namespace OrderAPI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly DaprClient _daprClient;
        public OrderController(DaprClient daprClient)
        {
            _daprClient=daprClient;
        }

        [HttpGet("Orders")]
        public async Task<IActionResult> GetOrders()
        {
            throw new NotImplementedException();
        }

        [HttpGet("Orders/{orderNumber}")]
        public async Task<IActionResult> GetOrder(int orderNumber)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Orders")]
        public async Task<IActionResult> CreateOrder([FromBody] Models.Order newOrder)
        {
            //TODO: Call o/p binding to save data

            // call publish event to indicate order is created
            await _daprClient.PublishEventAsync<Models.Order>("pubsub", "order-created", newOrder);

            return Accepted();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Dapr.Client;
using HealthMarketWebClient.Data;

namespace HealthMarketWebClient.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private DaprClient _daprClient;

        public ProductService(DaprClient daprClient)
        {
            _httpClient = DaprClient.CreateInvokeHttpClient("product-api");
            _daprClient = daprClient;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            // using var resp=await _httpClient.GetAsync("api/products",HttpCompletionOption.ResponseHeadersRead);

            // if (!resp.IsSuccessStatusCode)
            // {
            //     // probably log some stuff here
            //     return Enumerable.Empty<Product>();
            // }
            // var contentStream = await resp.Content.ReadAsStreamAsync();
            // var products = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(contentStream,
            //                 new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var products=Enumerable.Empty<Product>();;
            try
            {
                products = await _daprClient.InvokeMethodAsync<IEnumerable<Product>>(HttpMethod.Get, "product-api", "Products");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return products;
        }
    }
}
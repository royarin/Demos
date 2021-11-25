using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Service;

namespace ProductAPI.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService=productService;
        }

        
        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts(int page = 1, int limit = 20)
        {
            return Ok(await _productService.GetProducts(page, limit));
        }


        [HttpGet("Products/{sku}")]
        public async Task<IActionResult> GetProduct(string sku)
        {
            return Ok(await _productService.GetSingle(sku));
        }
    }
}

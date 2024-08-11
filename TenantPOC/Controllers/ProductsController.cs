using Microsoft.AspNetCore.Mvc;
using TenantPOC.Models;
using TenantPOC.Services;
using TenantPOC.Services.Models;

namespace TenantPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] CreateProductModel createProductModel)
        {
            var products = await _productService.CreateProduct(createProductModel);
            return Ok(products);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProduct([FromRoute] int id)
        {
            var products = await _productService.DeleteProduct(id);
            return Ok(products);
        }
    }
}

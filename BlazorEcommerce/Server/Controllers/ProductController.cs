using System.Data.SqlClient;
using BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces;
using BlazorEcommerce.Shared;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductManger _productManager;

        public ProductController(IProductManger productManager)
        {
            
            _productManager = productManager;
        }
       

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllProducts()
        {
            var products = await _productManager.GetAllProductsAsync();
            if (products.Data is null)
            {
                products.Message = "No products found";
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductById(Guid id)
        {
            var product = await _productManager.GetProductByIdAsync(id);
            if (product.Data is null)
            {
                product.Message = "Product with given id not found";
                return NotFound(product);
            }
            return Ok(product);
        }

    }
}

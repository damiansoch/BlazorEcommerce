using System.Data.SqlClient;
using BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces;
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
            var products = await _productManager.GetAllProducts();
            if(products is null)
                return NotFound();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await _productManager.GetProductById(id);
            if (product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("categoryId/{categoryId:guid}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(Guid categoryId)
        {
            var products = await _productManager.GetProductsByCategory(categoryId);
            if(products is null)
                return NotFound();
            return Ok(products);
        }

    }
}

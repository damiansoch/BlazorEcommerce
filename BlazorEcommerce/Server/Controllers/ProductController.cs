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
        
        private readonly IProductManger _productsManager;

        public ProductController(IProductManger productsManager)
        {
            
            _productsManager = productsManager;
        }
       

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllProducts()
        {
            var products = await _productsManager.GetAllProducts();
            
            return Ok(products);
        }

    }
}

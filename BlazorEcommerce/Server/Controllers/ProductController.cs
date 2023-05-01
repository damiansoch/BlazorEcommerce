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
            
            return Ok(products);
        }

    }
}

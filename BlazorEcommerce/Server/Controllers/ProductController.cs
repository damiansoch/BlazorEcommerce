using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //------------------------------------------- 
        //private static List<Product> Products = new List<Product>
        //{
        //    new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = "Book of the Dead 1",
        //        Description = "Weighing of the heart scene with en:Ammit sitting from the book of the dead of Hunefer. From the source: \"The judgement, from the papyrus of the scribe Hunefer. 19th Dynasty. Hunefer is conducted to the balance by jackal-headed Anubis. The monster Ammut crouches beneath the balance so as to swallow the heart should a life of wickedness be indicated. EA9901.",
        //        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d7/BD_Hunefer.jpg",
        //        Price = 9.99m
        //    },
        //    new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = "Self made picture of ancient Egyptian god Anubis",
        //        Description = "No machine-readable author provided. Ningyou assumed (based on copyright claims).",
        //        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Anubis_standing.jpg/296px-Anubis_standing.jpg?20060103235027",
        //        Price = 13.99m
        //    },
        //    new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = "Dios",
        //        Description = "Bi ha quí define a Teolochía como a sciencia que tracta de Dios, anque no s'alazeta en os metodos scientificos y no puede estar considerada como tal."+
        //                      "As personas que negan a existencia de dioses se claman ateas. A disaparición d'a certitut d'a existencia de Dios ye comentata por autors como Nietzsche. ",
        //        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/be/Pietro_Perugino_024.jpg/1920px-Pietro_Perugino_024.jpg",
        //        Price = 20m
        //    }
        //};
        //-------------------------------------------


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var products = await connection.QueryAsync<Product>("select * from products");
            return Ok(products.ToList());
        }

    }
}

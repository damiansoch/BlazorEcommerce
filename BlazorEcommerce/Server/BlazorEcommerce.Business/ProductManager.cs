using BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace BlazorEcommerce.Server.BlazorEcommerce.Business
{
    public class ProductManager : IProductManger
    {
        private readonly IConfiguration _configuration;

        public ProductManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           
            await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var products = await connection.QueryAsync<Product>("select * from products");
            return products;
        }
    }
}

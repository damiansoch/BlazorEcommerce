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


        public async Task<ServiceResponse<IEnumerable<Product>>> GetAllProductsAsync()
        {

            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                var response = new ServiceResponse<IEnumerable<Product>>()
                {
                    Data = await connection.QueryAsync<Product>("select * from products")
                };
                return response;
            }
            catch (Exception e)
            {
                var response = new ServiceResponse<IEnumerable<Product>>()
                {
                    Success = false,
                    Message = e.Message
                };
                return response;
            }
        }

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(Guid id)
        {
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                var response = new ServiceResponse<Product>()
                {
                    Data = await connection.QueryFirstAsync<Product>("select * from products where id = @Id", new { Id = id })
                };
                return response;
            }
            catch (Exception e)
            {
                var response = new ServiceResponse<Product>()
                {
                    Success = false,
                    Message = e.Message
                };
                return response;
            }
        }
    }
}

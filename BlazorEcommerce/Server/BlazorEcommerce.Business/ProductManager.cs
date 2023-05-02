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
        public async Task<ServiceResponse<IEnumerable<Product>>> GetAllProducts()
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
                Console.WriteLine(e);
                throw;
            }
            

            
        }

        public async Task<Product> GetProductById(Guid id)
        {
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var response = await connection.QueryFirstAsync<Product>("select * from products where id = @Id", new { Id = id });
                var variants = await connection.QueryAsync<ProductVariant>(
                    "select pt.name as typeName,pv.price,pv.originalPrice,pv.productId,pv.productTypeId from [dbo].[Products] p join [dbo].[ProductVariants] pv on p.id = pv.productId join [dbo].[ProductTypes] pt on pv.productTypeId = pt.id where p.id = @Id", new {Id =id });
                response.Variants = variants.ToList();
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var response = await connection.QueryAsync<Product>(
                    "select * from products where categoryId = @CategoryId", new { CategoryId = categoryId });
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

using System.Data.SqlClient;
using BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces;
using BlazorEcommerce.Shared;
using Dapper;

namespace BlazorEcommerce.Server.BlazorEcommerce.Repository
{
    public class ProductTypeRepository:IProductTypeRepository
    {
        private readonly IConfiguration _configuration;

        public ProductTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ProductType> GetById(Guid productTypeId)
        {
            const string query = "select * from productTypes where id = @Id";
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var response = await connection.QueryFirstAsync<ProductType>(query,new {Id = productTypeId});
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            const string query = "select * from productTypes";
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var response = await connection.QueryAsync<ProductType>(query);
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

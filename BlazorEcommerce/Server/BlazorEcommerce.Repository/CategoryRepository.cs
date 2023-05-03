using BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces;
using System.Data.SqlClient;
using Dapper;

namespace BlazorEcommerce.Server.BlazorEcommerce.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var response = await connection.QueryAsync<Category>("select * from categories");
                if (response is not null)
                {
                    return response;
                }

                throw new Exception("Cant find any categories");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

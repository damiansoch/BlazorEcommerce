using System.Data.SqlClient;
using BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces;
using Dapper;

namespace BlazorEcommerce.Server.BlazorEcommerce.Business
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IConfiguration _conf;

        public CategoryManager(IConfiguration conf)
        {
            _conf = conf;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {

            try
            {
                using (var connection = new SqlConnection(_conf.GetConnectionString("DefaultConnection")))
                {
                    var response = await connection.QueryAsync<Category>("select * from categories");
                    if (response is not null)
                    {
                        return response;
                    }

                    throw new Exception("Cant find any categories");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

using BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces;
using System.Data.SqlClient;
using Dapper;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.BlazorEcommerce.Repository
{
    public class VariantRepository:IVariantRepository
    {
        private readonly IConfiguration _configuration;

        public VariantRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<ProductVariant>> GetVariantsForProduct(Guid productId)
        {

            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var variants =
                    await connection.QueryAsync<ProductVariant>(
                        "select * from ProductVariants where productId = @ProductId", new { ProductId = productId });
                return variants;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<ProductVariant>> GetAllVariants()
        {
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var variants =
                    await connection.QueryAsync<ProductVariant>(
                        "select * from ProductVariants" );
                return variants;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

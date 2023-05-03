using BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces;
using System.Data.SqlClient;
using Dapper;

namespace BlazorEcommerce.Server.BlazorEcommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IVariantRepository _variantRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductRepository(IConfiguration configuration, IVariantRepository variantRepository, IProductTypeRepository productTypeRepository)
        {
            _configuration = configuration;
            _variantRepository = variantRepository;
            _productTypeRepository = productTypeRepository;
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var query = "select * from products";
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                var response = await connection.QueryAsync<Product>(query);

                var allVariants = await _variantRepository.GetAllVariants();
                response.ToList().ForEach(data => data.Variants = (allVariants.ToList().Where(i => i.ProductId == data.Id)).ToList());
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Product> GetAsync(Guid productId)
        {
            const string query = "select * from products where id = @Id";
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var response = await connection.QueryFirstAsync<Product>(query, new { Id = productId });
                var variants = await _variantRepository.GetVariantsForProduct(productId);
                response.Variants = variants.ToList();
                var allProductTypes = await _productTypeRepository.GetAllTypes();
                response.Variants.ForEach(variant => variant.ProductType = allProductTypes.ToList().First(i => i.Id == variant.ProductTypeId));
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(Guid categoryId)
        {
            try
            {
                await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var response = await connection.QueryAsync<Product>(
                    "select * from products where categoryId = @CategoryId", new { CategoryId = categoryId });
                var allVariants = await _variantRepository.GetAllVariants();
                response.ToList().ForEach(data => data.Variants = (allVariants.ToList().Where(i => i.ProductId == data.Id)).ToList());
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

using BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces;
using Dapper;

namespace BlazorEcommerce.Server.BlazorEcommerce.Business
{
    public class ProductManager : IProductManger
    {
        private readonly IConfiguration _configuration;
        private readonly IProductRepository _productRepository;

        public ProductManager(IConfiguration configuration,IProductRepository productRepository)
        {
            _configuration = configuration;
            _productRepository = productRepository;
        }
        public async Task<ServiceResponse<IEnumerable<Product>>> GetAllProducts()
        {
            var result = await _productRepository.GetAllAsync();
            if (result is not null)
            {
                var serviceResponseWithData = new ServiceResponse<IEnumerable<Product>>()
                {
                    Data = result
                };
                return serviceResponseWithData;
            }
            else
            {
                return null;
            }
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is not null)
            {
                return product;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            return await _productRepository.GetProductByCategory(categoryId);
        }

        public async Task<List<Product>> SearchProducts(string searchText)
        {
            var result = await _productRepository.GetAllAsync();
            result = result.ToList().Where(x => x.Title.Contains(searchText) || x.Description.Contains(searchText));
            if (result is not null)
            {
                
                
                return result.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}

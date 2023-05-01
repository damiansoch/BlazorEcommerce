using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using BlazorEcommerce.Client.Services.Business.Services;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.Business
{
    public class ProductManager:IProductManager
    {
        private readonly HttpClient _client;

        public ProductManager(HttpClient client)
        {
            _client = client;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public async Task GetProducts()
        {
            var result = await _client.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");

            if (result is not null && result.Data is not null)
            {
                Products = result.Data;
            }
            
        }

        public Product Product { get; set; }
        public async Task<ServiceResponse<Product>> GetProductById(Guid id)
        {
            try
            {
                var result = await _client.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
                if (!result.Success)
                {
                    Product = result.Data;
                }
                return result;
            }
            catch (Exception e)
            {
                return new ServiceResponse<Product>()
                {
                    Success = false,
                    Message = e.Message,
                };
            }
            
        }
    }
}

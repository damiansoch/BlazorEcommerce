using System.Net.Http.Json;
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

        public async Task<Product> GetProductById(Guid id)
        {
            var result = await _client.GetFromJsonAsync<Product>($"api/Product/{id}");
            if (result is not null)
            {
                return result;
            }

            throw new Exception("Not found");
        }
    }
}

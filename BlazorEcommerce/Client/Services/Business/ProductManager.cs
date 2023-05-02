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

        public event Action ProductChanged;
        public List<Product> Products { get; set; } = new List<Product>();
        public async Task GetProducts(string? categoryId)
        {
            if (categoryId == null)
            {
                var result = await _client.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");

                if (result is not null && result.Data is not null)
                {
                    Products = result.Data;
                }
            }
            else
            {
                var result = await _client.GetFromJsonAsync<List<Product>>($"api/Product/categoryId/{categoryId}");

                if (result is not null )
                {
                    Products = result;
                }
            }
            
            ProductChanged.Invoke();
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

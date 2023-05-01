using System.Net.Http.Json;
using BlazorEcommerce.Client.Services.Business.Interfaces;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.Business
{
    public class CategoryManagerClient:ICategoryManagerClient
    {
        private readonly HttpClient _client;

        public CategoryManagerClient(HttpClient client)
        {
            _client = client;
        }
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategoriesAsync()
        {
            var result = await _client.GetFromJsonAsync<List<Category>>("api/Category");
            if (result is not null)
            {
                Categories = result;
            }
        }
    }
}

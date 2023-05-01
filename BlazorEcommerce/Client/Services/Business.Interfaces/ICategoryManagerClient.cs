using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.Business.Interfaces
{
    public interface ICategoryManagerClient
    {
         List<Category> Categories { get; set; }
        Task GetCategoriesAsync();
    }
}

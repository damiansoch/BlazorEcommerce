using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.Business.Services
{
    public interface IProductManager
    {
        event Action ProductChanged;
        public List<Product> Products { get; set; }
        Task GetProducts(string? categoryId = null);
        Task<Product> GetProductById(Guid id);
    }
}

using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.Business.Services
{
    public interface IProductManager
    {
        public List<Product> Products { get; set; }
        Task GetProducts();
        Task<ServiceResponse<Product>> GetProductById(Guid id);
    }
}

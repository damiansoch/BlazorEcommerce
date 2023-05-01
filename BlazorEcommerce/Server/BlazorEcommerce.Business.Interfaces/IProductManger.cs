namespace BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces
{
    public interface IProductManger
    {
        Task<ServiceResponse<IEnumerable<Product>>> GetAllProductsAsync();
        Task<ServiceResponse<Product>> GetProductByIdAsync(Guid id);
    }
}

namespace BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(Guid productId);
        Task<IEnumerable<Product>>GetProductByCategory(Guid categoryId);
    }
}

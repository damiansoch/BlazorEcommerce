namespace BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces
{
    public interface IProductManger
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}

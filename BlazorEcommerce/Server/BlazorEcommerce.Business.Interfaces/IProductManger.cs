namespace BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces
{
    public interface IProductManger
    {
        Task<IEnumerable<ProductManager>> GetAllProducts();
    }
}

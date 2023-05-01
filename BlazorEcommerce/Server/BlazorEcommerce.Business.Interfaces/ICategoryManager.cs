namespace BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces
{
    public interface ICategoryManager
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}

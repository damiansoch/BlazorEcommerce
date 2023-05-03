namespace BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}

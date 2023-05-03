using System.Data.SqlClient;
using BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces;
using BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces;
using Dapper;

namespace BlazorEcommerce.Server.BlazorEcommerce.Business
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IConfiguration _conf;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(IConfiguration conf,ICategoryRepository categoryRepository)
        {
            _conf = conf;
            _categoryRepository = categoryRepository;

        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return categories;
        }
    }
}

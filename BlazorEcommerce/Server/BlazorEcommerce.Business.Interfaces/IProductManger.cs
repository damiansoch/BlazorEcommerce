﻿namespace BlazorEcommerce.Server.BlazorEcommerce.Business.Interfaces
{
    public interface IProductManger
    {
        
        Task<ServiceResponse<IEnumerable<Product>>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
        Task<List<Product>> SearchProducts(string searchText);
    }
}

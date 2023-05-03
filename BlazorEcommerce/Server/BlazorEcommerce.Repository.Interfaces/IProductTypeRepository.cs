namespace BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces
{
    public interface IProductTypeRepository
    {
        Task <ProductType> GetById(Guid productTypeId);
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}

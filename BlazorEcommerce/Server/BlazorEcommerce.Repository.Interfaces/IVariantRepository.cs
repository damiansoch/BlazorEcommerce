namespace BlazorEcommerce.Server.BlazorEcommerce.Repository.Interfaces
{
    public interface IVariantRepository
    {
        Task<IEnumerable<ProductVariant>> GetVariantsForProduct(Guid productId);
        Task<IEnumerable<ProductVariant>> GetAllVariants();
    }
}

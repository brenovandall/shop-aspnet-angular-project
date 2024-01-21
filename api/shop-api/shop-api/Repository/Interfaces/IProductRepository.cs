using shop_api.Models;

namespace shop_api.Repository.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync(); // returns a reandonly list, just beacause
                                                     // i wouldnt add or update something from the controller
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}

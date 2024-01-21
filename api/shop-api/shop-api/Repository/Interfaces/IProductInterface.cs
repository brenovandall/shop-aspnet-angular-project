using shop_api.Models;

namespace shop_api.Repository.Interfaces;

public interface IProductInterface
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync(); // returns a reandonly list, just beacause
                                                     // i wouldnt add or update something from the controller
}

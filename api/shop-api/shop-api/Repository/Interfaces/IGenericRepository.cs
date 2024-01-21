using shop_api.Models;
using shop_api.Repository.Specifications;

namespace shop_api.Repository.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity // T will be every class that has inheritance from BaseEntity, like Product, ProductBrand, ProductType...
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync(); // returns a reandonly list, just beacause
                                          // i wouldnt add or update something from the controller
    Task<T> GetsValueWithSpecification(ISpecification<T> specification);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
    Task<int> CountAsync(ISpecification<T> spec);
}

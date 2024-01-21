using shop_api.Models;

namespace shop_api.Repository.Specifications;

public class ProductWithFiltersForCountSpecification : Specification<Product>
{
    public ProductWithFiltersForCountSpecification(ProductParams pParams)
        : base(x =>
            (string.IsNullOrEmpty(pParams.Search) || x.Name.ToLower().Contains(pParams.Search)) &&
            (!pParams.BrandId.HasValue || x.ProductBrandId == pParams.BrandId) &&
            (!pParams.TypeId.HasValue || x.ProductTypeId == pParams.TypeId)
        )
    {
    }
}

using shop_api.Models;
using System.Globalization;

namespace shop_api.Repository.Specifications;

public class ProductWithTypeAndBrandSpecification : Specification<Product>
{
    public ProductWithTypeAndBrandSpecification(ProductParams pParams)
        : base(x =>
            (string.IsNullOrEmpty(pParams.Search) || x.Name.ToLower().Contains(pParams.Search)) &&
            (!pParams.BrandId.HasValue || x.ProductBrandId == pParams.BrandId) &&
            (!pParams.TypeId.HasValue || x.ProductTypeId == pParams.TypeId)
        )
    {
        AddIncludes(x => x.ProductType);
        AddIncludes(x => x.ProductBrand);
        AddOrderBy(x => x.Name);
        ApplyPaging(pParams.PageSize * (pParams.PageIndex - 1), pParams.PageSize);

        if (!string.IsNullOrEmpty(pParams.Sort))
        {
            switch (pParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }
    }

    public ProductWithTypeAndBrandSpecification(int id) : base(x => x.Id == id)
    {
        AddIncludes(x => x.ProductBrand);
        AddIncludes(x => x.ProductType);
    }
}

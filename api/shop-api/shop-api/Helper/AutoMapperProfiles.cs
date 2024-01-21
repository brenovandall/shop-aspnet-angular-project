using AutoMapper;
using shop_api.Data.DTOs;
using shop_api.Models;

namespace shop_api.Helper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Product, ReadProductDto>()
            .ForMember(p => p.ProductBrand, opt => opt.MapFrom(s => s.ProductBrand.Name)) // here i can configure the source result, the ProductBrand object will receive the ProductBrand.Name as string
            .ForMember(p => p.ProductType, opt => opt.MapFrom(s => s.ProductType.Name))
            .ForMember(p => p.ImageUrl, opt => opt.MapFrom<ProductUrlResolver>());
    }
}

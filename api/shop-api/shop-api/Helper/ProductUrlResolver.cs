using AutoMapper;
using AutoMapper.Execution;
using shop_api.Data.DTOs;
using shop_api.Models;

namespace shop_api.Helper;

public class ProductUrlResolver : IValueResolver<Product, ReadProductDto, string>
{
    private readonly IConfiguration _configuration;
    public ProductUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Resolve(Product source, ReadProductDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ImageUrl))
        {
            return _configuration["ApiUrl"] + source.ImageUrl;
        }

        return null;
    }
}

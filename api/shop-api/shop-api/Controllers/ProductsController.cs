using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using shop_api.Data.DTOs;
using shop_api.Errors;
using shop_api.Helper;
using shop_api.Models;
using shop_api.Repository.Interfaces;
using shop_api.Repository.Specifications;

namespace shop_api.Controllers;

public class ProductsController : UrlHandleApiBaseController // this class just uses those two methods [ApiController] and [Route], so i dont need to do this assignature all the times
{
    public IGenericRepository<Product> _productRepos { get; }
    public IGenericRepository<ProductBrand> _productBrandRepos { get; }
    public IGenericRepository<ProductType> _productTypeRepos { get; }
    private IMapper _mapper;

    public ProductsController(
        IGenericRepository<Product> productRepos,
        IGenericRepository<ProductBrand> productBrandRepos,
        IGenericRepository<ProductType> productTypeRepos,
        IMapper mapper)
    {
        _productRepos = productRepos;
        _productBrandRepos = productBrandRepos;
        _productTypeRepos = productTypeRepos;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ReadProductDto>>> GetProducts([FromQuery] ProductParams pParams)
    {
        var specification = new ProductWithTypeAndBrandSpecification(pParams);

        var count = new ProductWithFiltersForCountSpecification(pParams);

        var totalItems = await _productRepos.CountAsync(count);

        var products = await _productRepos.ListAsync(specification);

        // using auto mapper to map the IReadOnlyList that is comming from repository to a IReadOnlyList of DTO
        var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ReadProductDto>>(products);

        return Ok(new Pagination<ReadProductDto>(pParams.PageIndex, pParams.PageSize, totalItems, data));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)] // this is an example how i can documentate the response to swagger
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById(int id)
    {
        var specification = new ProductWithTypeAndBrandSpecification(id);

        var product = await _productRepos.GetsValueWithSpecification(specification);

        if (product == null) return NotFound(new ApiResponse(404));

        // using auto mapper to map the product to the dto and send to the ui
        // here, i need to be careful only with brands and product types, these are another objects,
        // so auto mapper cant map an object to a string (the name of the object only)... the profile needs to be configured
        // see more at [Helper\AutoMapperProfiles.cs]
        return Ok(_mapper.Map<Product, ReadProductDto>(product));
    }

    [HttpGet]
    [Route("brands")]
    public async Task<IActionResult> GetProductBrands()
    {
        var productBrands = await _productBrandRepos.GetAllAsync();

        return Ok(productBrands);
    }

    [HttpGet]
    [Route("types")]
    public async Task<IActionResult> GetProductTypes()
    {
        var productTypes = await _productTypeRepos.GetAllAsync();

        return Ok(productTypes);
    }
}

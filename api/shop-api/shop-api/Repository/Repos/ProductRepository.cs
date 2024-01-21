using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Models;
using shop_api.Repository.Interfaces;

namespace shop_api.Repository.Repos;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationStoreDbContext _context;
    public ProductRepository(ApplicationStoreDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _context.Products_Table
            .Include(x => x.ProductType)
            .Include(x => x.ProductBrand)
            .FirstOrDefaultAsync(
                product => product.Id == id
            );

        return product;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products_Table
            .Include(x => x.ProductType)
            .Include(x => x.ProductBrand)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        return await _context.ProductBrands_Table
            .ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await _context.ProductTypes_Table
            .ToListAsync();
    }
}

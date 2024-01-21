using Microsoft.EntityFrameworkCore;
using shop_api.Models;

namespace shop_api.Data;

public class ApplicationStoreDbContext : DbContext
{
    public ApplicationStoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products_Table { get; set; }
    public DbSet<ProductBrand> ProductBrands_Table { get; set; }
    public DbSet<ProductType> ProductTypes_Table { get; set; }
}

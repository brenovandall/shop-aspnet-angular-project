namespace shop_api.Models;

public class Product : BaseEntity // the base entity is just the id property
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public ProductType ProductType { get; set; }
    public int ProductTypeId { get; set; }
    public ProductBrand ProductBrand { get; set; }
    public int ProductBrandId { get; set; }
}

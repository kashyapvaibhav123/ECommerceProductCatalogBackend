using ECommerceProductCatalog.Domain.Enums;

namespace ECommerceProductCatalog.Domain.Entities;

public class Product : Base
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public ProductCategories Category { get; set; }

    public string? ImageUrl { get; set; }

    public int StockQuantity { get; set; }
}
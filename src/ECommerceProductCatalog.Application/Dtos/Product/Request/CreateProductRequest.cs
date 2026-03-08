using ECommerceProductCatalog.Domain.Enums;

namespace ECommerceProductCatalog.Application.Dtos.Product.Request;

public class CreateProductRequest
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public ProductCategories Category { get; set; }

    public string? ImageUrl { get; set; }

    public int StockQuantity { get; set; }
}
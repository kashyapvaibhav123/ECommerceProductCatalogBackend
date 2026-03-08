using ECommerceProductCatalog.Domain.Enums;
namespace ECommerceProductCatalog.Application.Dtos.Product.Response;

public class GetProductsResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public ProductCategories Category { get; set; }

    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; }   // IMPORTANT
    public string? Description { get; set; }


}
namespace ECommerceProductCatalog.Application.Dtos.Product.Request;

public class GetProductsRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy { get; set; }
    public bool Desc { get; set; } = false;
    public string? Category { get; set; }
    public string? Search { get; set; }
    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

}
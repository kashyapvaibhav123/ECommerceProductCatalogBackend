using ECommerceProductCatalog.Application.Commom.Response;
using ECommerceProductCatalog.Application.Dtos.Product.Request;
using ECommerceProductCatalog.Application.Dtos.Product.Response;

namespace ECommerceProductCatalog.Application.Interfaces;

public interface IProductService
{
    Task<PagedResult<GetProductsResponse>> GetAllProducts(GetProductsRequest request);
    Task<int> CreateProduct(CreateProductRequest request);
    Task<GetProductsResponse?> GetProductById(int id);
}
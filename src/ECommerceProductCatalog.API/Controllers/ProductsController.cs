using Microsoft.AspNetCore.Mvc;
using ECommerceProductCatalog.Application.Interfaces;
using ECommerceProductCatalog.Application.Dtos.Product.Request;

namespace ECommerceProductCatalog.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET /api/products (Get All Products (Optionally by Page,PageSize and Sorting))
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
    {
        var result = await _productService.GetAllProducts(request);
        return Ok(result);
    }
    // POST /api/products (Create Products)
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var id = await _productService.CreateProduct(request);

        return Created($"/api/products/{id}", new { createdId = id });
    }
    // GET /api/products/{id} (Get Product By Id)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);

        if (product == null)
            return NotFound(new { message = "Product not found" });

        return Ok(product);
    }
}
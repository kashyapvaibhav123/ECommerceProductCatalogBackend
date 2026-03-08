using System.Linq.Expressions;
using AutoMapper;
using ECommerceProductCatalog.Application.Commom.Response;
using ECommerceProductCatalog.Application.Dtos.Product.Request;
using ECommerceProductCatalog.Application.Dtos.Product.Response;
using ECommerceProductCatalog.Application.Extension;
using ECommerceProductCatalog.Application.Interfaces;
using ECommerceProductCatalog.Domain.Entities;
using ECommerceProductCatalog.Domain.Enums;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;
    public ProductService(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    //Get All Products Apply Pagination Here
    public async Task<PagedResult<GetProductsResponse>> GetAllProducts(GetProductsRequest request)
    {
        Expression<Func<Product, bool>>? filter = null;

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.ToLower();

            filter = p =>
                p.Name.ToLower().Contains(search) ||
                (p.Description != null && p.Description.ToLower().Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(request.Category))
        {
            if (int.TryParse(request.Category, out var categoryValue))
            {
                var categoryEnum = (ProductCategories)categoryValue;

                filter = filter == null
                    ? p => p.Category == categoryEnum
                    : filter.And(p => p.Category == categoryEnum);
            }
        }

        if (request.MinPrice.HasValue)
        {
            filter = filter == null
                ? p => p.Price >= request.MinPrice.Value
                : filter.And(p => p.Price >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            filter = filter == null
                ? p => p.Price <= request.MaxPrice.Value
                : filter.And(p => p.Price <= request.MaxPrice.Value);
        }

        var products = await _repository.Get(
            request.Page,
            request.PageSize,
            request.OrderBy,
            request.Desc,
            filter
        );

        var totalCount = await _repository.Count(filter);

        var items = _mapper.Map<IEnumerable<GetProductsResponse>>(products);

        return new PagedResult<GetProductsResponse>(
            items,
            totalCount,
            request.Page,
            request.PageSize
        );
    }
    // GET PRODUCT BY ID
    public async Task<GetProductsResponse?> GetProductById(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return null;

        return _mapper.Map<GetProductsResponse>(product);
    }
    //Create Products
    public async Task<int> CreateProduct(CreateProductRequest request)
    {
        var product = _mapper.Map<Product>(request);

        await _repository.AddAsync(product);


        return product.Id;
    }
}
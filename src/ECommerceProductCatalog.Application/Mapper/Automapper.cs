using AutoMapper;
using ECommerceProductCatalog.Domain.Entities;
using ECommerceProductCatalog.Application.Dtos.Product.Response;
using ECommerceProductCatalog.Application.Dtos.Product.Request;

namespace ECommerceProductCatalog.Application.Mapper;

public class Automapper : Profile
{
    public Automapper()
    {
        CreateMap<Product, GetProductsResponse>();
        CreateMap<CreateProductRequest, Product>();
    }
}
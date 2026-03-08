




using Microsoft.Extensions.DependencyInjection;
using ECommerceProductCatalog.Application.Interfaces;
using ECommerceProductCatalog.Infrastructure.Repositories;

namespace ECommerceProductCatalog.Application.DependencyInjection;

public static class ServiceDependency
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Product Service  ← ADD HERE
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
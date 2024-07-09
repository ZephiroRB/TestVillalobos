using Application.Core.Products;
using Application.Multitenancy;
using Infrastructure.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Multitenancy
{
    internal static class Startup
    {
        internal static IServiceCollection AddMultitenancy(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddTransient<IProductService, ProductService>()
                .AddTransient<ITenantService, TenantService>();
        }

        internal static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MultiTenantMiddleware>();
        }
    }
}

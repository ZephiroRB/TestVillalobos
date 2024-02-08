using Application.Auth.Users;
using Application.Core.Organizations;
using Application.Core.Products;
using Application.Multitenancy;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Infrastructure.Auth;

namespace Infrastructure.Core
{
    internal static class Startup
    {
        internal static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services
                .AddScoped<IOrganizationService, OrganizationService>()
                .AddScoped<IProductService, ProductService>();
        }
    }
}
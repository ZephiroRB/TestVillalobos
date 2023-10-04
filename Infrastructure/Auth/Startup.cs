using Application.Auth.Tokens;
using Application.Auth.Users;
using Application.Common.Interfaces;
using Application.Core.Organizations;
using Application.Core.Products;
using Infrastructure.Auth.Jwt;
using Infrastructure.Auth.Permissions;
using Infrastructure.Common.Services;
using Infrastructure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Infrastructure.Auth;

namespace Infrastructure.Auth
{
    internal static class Startup
    {
        internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddPermissions()
                .AddJwtAuth(config);
        }

        private static IServiceCollection AddPermissions(this IServiceCollection services) =>
        services
            .AddAuthorization(options =>
            {
                options.AddPolicy("BasicUserPermissionsPolicy", policy =>
                {
                    policy.Requirements.Add(new BasicUserPermissionsRequirement());
                });
                options.AddPolicy("AdminUserPermissionsPolicy", policy =>
                {
                    policy.Requirements.Add(new AdminUserPermissionsRequirement());
                });
            })
            .AddScoped<IAuthorizationHandler, AdminUserPermissionsHandler>()
            .AddScoped<IAuthorizationHandler, BasicUserPermissionsHandler>()
            .AddTransient<IOrganizationService, OrganizationService>()
            .AddTransient<ISerializerService, NewtonSoftService>()
            .AddTransient<IProductService, ProductService>()
            .AddTransient<ITokenService, TokenService>()
            .AddTransient<IUserService, UserService>();
    }
}

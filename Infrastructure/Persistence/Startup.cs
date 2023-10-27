using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Initialization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    internal static class Startup
    {
        internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            var strMaster = config.GetConnectionString("MasterBaseConnection");
            var strBaseConnection = config.GetConnectionString("BaseConnection");
            
            return services
                .AddDbContext<MasterDbContext>(options => options.UseSqlServer(strMaster))
                .AddDbContext<ProductDbContext>(options => options.UseSqlServer(strBaseConnection))
                .AddTransient<IDatabaseInitializer, DatabaseInitializer>()
                .AddTransient<ApplicationDbInitializer>()
                .AddTransient<ApplicationDbSeeder>();
        }
    }
}

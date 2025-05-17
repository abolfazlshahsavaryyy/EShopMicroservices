global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection service,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            service.AddDbContext<ApplicationDbContext>(option =>
            {
                option.AddInterceptors(new AuditableEntityInterceptors());
                option.UseSqlServer(connectionString);
            });
            return service;
        }
    }
}

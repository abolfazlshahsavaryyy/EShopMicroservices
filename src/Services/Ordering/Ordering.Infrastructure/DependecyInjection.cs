global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Application.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection service,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            service.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptors>();
            service.AddScoped<ISaveChangesInterceptor, DispatchDomainEventIntercepter>();

            service.AddDbContext<ApplicationDbContext>((sp,option) =>
            {
                option.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
                option.UseSqlServer(connectionString);
            });

            service.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return service;
        }
    }
}

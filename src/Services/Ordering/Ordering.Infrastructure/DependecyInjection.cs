using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection service,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            return service;
        }
    }
}

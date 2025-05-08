namespace Ordering.API
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
            //app.UseCarter();
            return app;
        }
    }
}

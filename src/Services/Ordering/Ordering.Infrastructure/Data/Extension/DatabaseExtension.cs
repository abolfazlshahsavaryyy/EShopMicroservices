using Microsoft.AspNetCore.Builder;

namespace Ordering.Infrastructure.Data.Extension
{
    public static class DatabaseExtension
    {
        public static async Task InitialiesDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();
        }
    }
}

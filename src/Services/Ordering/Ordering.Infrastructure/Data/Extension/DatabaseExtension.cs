using Microsoft.AspNetCore.Builder;

namespace Ordering.Infrastructure.Data.Extension
{
    public static class DatabaseExtension
    {
        public static async Task InitialiesDatabaseAsync(this WebApplication app)
        {
            //add migration
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedCustomer(context);
            await SeedProduct(context);
            await SeedOrderWithItem(context);


        }

        private static async Task SeedOrderWithItem(ApplicationDbContext context)
        {
            if (!await context.orders.AnyAsync())
            {
                await context.orders.AddRangeAsync(InitData.OrderWithItem);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedProduct(ApplicationDbContext context)
        {
            if (!await context.products.AnyAsync())
            {
                await context.products.AddRangeAsync(InitData.Product);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedCustomer(ApplicationDbContext context)
        {
            if (! await context.customers.AnyAsync())
            {
                await context.customers.AddRangeAsync(InitData.Customer);
                await context.SaveChangesAsync();
            }
        }
    }
}

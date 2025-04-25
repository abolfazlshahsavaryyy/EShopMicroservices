using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            
            if(await session.Query<Product>().AnyAsync())
            {
                return;
            }
            session.Store<Product>(GetSeedProducts());

            await session.SaveChangesAsync();
        }
        private static IEnumerable<Product> GetSeedProducts()
        {
            var productsSeed = new List<Product>
    {
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Laptop",
            Category = new List<string> { "Electronics", "Computers" },
            Description = "High-performance laptop suitable for work and gaming.",
            ImageFile = "laptop.png",
            Price = 999.99M
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Smartphone",
            Category = new List<string> { "Electronics", "Mobile Devices" },
            Description = "Latest model smartphone with cutting-edge features.",
            ImageFile = "smartphone.png",
            Price = 799.99M
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Wireless Headphones",
            Category = new List<string> { "Electronics", "Audio" },
            Description = "Noise-cancelling over-ear headphones with long battery life.",
            ImageFile = "headphones.png",
            Price = 199.99M
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Smartwatch",
            Category = new List<string> { "Wearables", "Fitness" },
            Description = "Track your fitness goals with this stylish smartwatch.",
            ImageFile = "smartwatch.png",
            Price = 149.99M
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Gaming Mouse",
            Category = new List<string> { "Electronics", "Accessories" },
            Description = "Ergonomic mouse with customizable buttons and RGB lighting.",
            ImageFile = "gaming_mouse.png",
            Price = 59.99M
        }
    };

            return productsSeed;
        }

    }
}

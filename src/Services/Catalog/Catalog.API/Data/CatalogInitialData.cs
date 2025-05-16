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
            Id = new Guid("b94ed2b3-f94f-4458-bc49-8fc6d2e7f114"),
            Name = "Laptop",
            Category = new List<string> { "Electronics", "Computers" },
            Description = "High-performance laptop suitable for work and gaming.",
            ImageFile = "laptop.png",
            Price = 999.99M
        },
        new Product
        {
            Id =  new Guid("3c998547-cf15-4b5d-a635-291f3f7b5bc2"),
            Name = "Smartphone",
            Category = new List<string> { "Electronics", "Mobile Devices" },
            Description = "Latest model smartphone with cutting-edge features.",
            ImageFile = "smartphone.png",
            Price = 799.99M
        },
        new Product
        {
            Id = new Guid("efb9e52f-3f12-4b57-bc44-7b7e69ff80e2"),
            Name = "Wireless Headphones",
            Category = new List<string> { "Electronics", "Audio" },
            Description = "Noise-cancelling over-ear headphones with long battery life.",
            ImageFile = "headphones.png",
            Price = 199.99M
        },
        new Product
        {
            Id = new Guid("6cf5bbf0-2558-4cf4-9f35-ec684b1f9aa7"),
            Name = "Smartwatch",
            Category = new List<string> { "Wearables", "Fitness" },
            Description = "Track your fitness goals with this stylish smartwatch.",
            ImageFile = "smartwatch.png",
            Price = 149.99M
        },
        new Product
        {
            Id = new Guid("8a83e15d-b4d2-4d99-bc98-2f409c5e2da8"),
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

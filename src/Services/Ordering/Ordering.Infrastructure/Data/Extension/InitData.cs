
namespace Ordering.Infrastructure.Data.Extension
{
    internal class InitData
    {
        public static IEnumerable<Customer> Customer =>
            new List<Customer>
            {
                Ordering.Domain.Models.Customer.Create(CustomerId.Of(new Guid("9f1e3c8a-7b7e-4c79-9c9f-56e9c5c3f8b1")),"Abolfazl","Abolfazl@gmail.com"),
                Ordering.Domain.Models.Customer.Create(CustomerId.Of(new Guid("4d6a1b9a-6d72-45d0-9d9e-3f4f6f0dcfab")),"Amin","Amin@gmail.com")

                

            };
        public static IEnumerable<Product> Product =>
            new List<Product>
            {
                Ordering.Domain.Models.Product.Create(ProductId.Of( new Guid("b94ed2b3-f94f-4458-bc49-8fc6d2e7f114")),"Laptop",999.99M),
                Ordering.Domain.Models.Product.Create(ProductId.Of( new Guid("3c998547-cf15-4b5d-a635-291f3f7b5bc2")),"Smartphone",799.99M),
                Ordering.Domain.Models.Product.Create(ProductId.Of( new Guid("efb9e52f-3f12-4b57-bc44-7b7e69ff80e2")),"Wireless Headphones",199.99M),
                Ordering.Domain.Models.Product.Create(ProductId.Of( new Guid("6cf5bbf0-2558-4cf4-9f35-ec684b1f9aa7")),"Smartwatch",149.99M),
                Ordering.Domain.Models.Product.Create(ProductId.Of( new Guid("8a83e15d-b4d2-4d99-bc98-2f409c5e2da8")),"Gaming Mouse", 59.99M),

            };

        public static IEnumerable<Order> OrderWithItem
        {
            get
            {
                var address1 = Address.Of("Abolfazl", "Shahsavari", "Abolfazl@gmail.com", "rashidi", "Iran", "Kermanshah", "1234");
                var address2 = Address.Of("Amin", "Shiravani", "Amin@gmail.com", "posht saypa", "Iran", "Marvdasht", "5678");

                var pay1 = Payment.Of("Abolfazl", "1111222233334444", "7/7", "966", 1);
                var pay2 = Payment.Of("Amin", "1111222255554444", "6/12", "946", 2);

                var order1 = Order.Create
                    (
                    OrderId.Of(new Guid()),
                    CustomerId.Of(new Guid("9f1e3c8a-7b7e-4c79-9c9f-56e9c5c3f8b1")),
                    OrderName.Of("order 1"),
                    address1,
                    address1,
                    pay1



                    );
                order1.Add(ProductId.Of(new Guid("b94ed2b3-f94f-4458-bc49-8fc6d2e7f114")), 2, 2 * 999.99M);
                order1.Add(ProductId.Of(new Guid("3c998547-cf15-4b5d-a635-291f3f7b5bc2")), 1,  799.99M);
                var order2 = Order.Create
                    (
                    OrderId.Of(new Guid()),
                    CustomerId.Of(new Guid("4d6a1b9a-6d72-45d0-9d9e-3f4f6f0dcfab")),
                    OrderName.Of("order 2"),
                    address2,
                    address2,
                    pay2



                    );
                order2.Add(ProductId.Of(new Guid("efb9e52f-3f12-4b57-bc44-7b7e69ff80e2")), 3, 3 * 199.99M);
                order2.Add(ProductId.Of(new Guid("6cf5bbf0-2558-4cf4-9f35-ec684b1f9aa7")), 2, 2* 149.99M);

                return new List<Order> { order1, order2 };




            }
        }
    }
}

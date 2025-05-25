using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Models
{
    public class OrderItem:Entity<OrderItemId>
    {
        public OrderId OrderId { get;private set; }
        public Order Order { get; private set; } = default!;
        //each OrderItem has the qunique productId
        public ProductId ProductId { get; private set; }
        public int Quantity { get;private set; }
        public decimal Price { get;private set; }
        internal OrderItem(OrderId OrderId,ProductId ProductId,int Quantity,decimal Price)
        {
            this.Id = OrderItemId.Of(Guid.NewGuid());
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
            this.Price = Price;
            
        }

    }
}

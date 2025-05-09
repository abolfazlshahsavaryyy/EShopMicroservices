using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Models
{
    public class OrderItem:Entity<Guid>
    {
        public Guid OrderId { get;private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get;private set; }
        public decimal Price { get;private set; }
        internal OrderItem(Guid OrderId,Guid ProductId,int Quantity,decimal Price)
        {
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
            this.Price = Price;
            
        }

    }
}

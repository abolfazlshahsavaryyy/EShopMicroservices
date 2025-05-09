namespace Ordering.Domain.ValueObjects
{
    public class OrderItemId
    {
        public Guid Value { get; }
        private OrderItemId(Guid value)
        {
            Value = value;
        }

        public static OrderItemId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if(value ==Guid.Empty)
            {
                throw new DomainException("OrderItem Id can't be empty");
            }
            return new OrderItemId(value);
        }
    }
}

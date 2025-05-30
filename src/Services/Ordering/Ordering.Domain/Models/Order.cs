﻿namespace Ordering.Domain.Models
{
    public class Order:Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItem => _orderItems.AsReadOnly();
        public CustomerId CustomerId { get; private set; } = default!;
        public OrderName OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } =OrderStatus.Pending!;
        public decimal TotalPrice 
        {
            get => OrderItem.Sum(x => x.Price * x.Quantity); 
            private set { }

        }
        public static Order Create(OrderId orderId,CustomerId customerId,
            OrderName orderName,Address shippingAddress,Address billingAddress,
            Payment payment)
        {
            var order = new Order
            {
                Id = orderId,
                CustomerId = customerId,
                OrderName = orderName,
                ShippingAddress = shippingAddress,
                BillingAddress = billingAddress,
                Payment = payment,
                Status = OrderStatus.Pending
            };
            order.AddDomainEvent(new OrderCreatedEvent(order));
            return order;

        }
        public void Update(OrderName orderName, Address shippingAddress,
            Address billingAddress, Payment payment,OrderStatus status)
        {
            this.OrderName = orderName;
            this.ShippingAddress = shippingAddress;
            this.BillingAddress = billingAddress;
            this.Payment = payment;
            this.Status = status;

            this.AddDomainEvent(new OrderUpdateEvent(this));
            
        }
        public void Add(ProductId productId,int quantity,
        decimal price)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            var orderItem = new OrderItem(this.Id, productId, quantity, price);
            _orderItems.Add(orderItem);

        }
        
        public void Rmove(ProductId productId)
        {
            var orderItem = _orderItems.FirstOrDefault(o => o.ProductId== productId);
            if(orderItem is not null)
            {
                _orderItems.Remove(orderItem);
            }
            

        }



    }
}

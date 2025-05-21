namespace Ordering.Application.Orders.Queries.GetOrdersByName;
public class GetOrdersByNameHandler
    (IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersByNameQuery, GetOrderByNameResult>
{
    public async Task<GetOrderByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        //get order by name
        //return it
        var orders = await dbContext.Orders
            .Include(o => o.OrderItem)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.Contains(query.name))
            .OrderBy(o => o.OrderName)
            .ToListAsync(cancellationToken);

        var dtoOrders = ProjectToOrderDto(orders);
        return new GetOrderByNameResult(dtoOrders);
    }

    private IEnumerable<OrderDto> ProjectToOrderDto(List<Order> orders)
    {
        List <OrderDto> orderDtos= new();
        foreach(var order in orders)
        {
            var orderDto = new OrderDto
            (
                Id: order.Id.Value,
                CustomerId: order.CustomerId.Value,
                OrderName: order.OrderName.Value,
                ShippingAddress: new AddressDto
                (
                    order.ShippingAddress.FirstName,
                    order.ShippingAddress.LastName,
                    order.ShippingAddress.EmailAddress,
                    order.ShippingAddress.AddressLine,
                    order.ShippingAddress.Country,
                    order.ShippingAddress.State,
                    order.ShippingAddress.ZipCode

                ),
                BillingAddress: new AddressDto
                (
                    order.BillingAddress.FirstName,
                    order.BillingAddress.LastName,
                    order.BillingAddress.EmailAddress,
                    order.BillingAddress.AddressLine,
                    order.BillingAddress.Country,
                    order.BillingAddress.State,
                    order.BillingAddress.ZipCode

                ),
                Payment:new PaymentDto(order.Payment.CartName,
                order.Payment.CartNumber,
                order.Payment.Expiration,
                order.Payment.CVV,
                order.Payment.PaymentMethid),
                Status: order.Status,
                OrderItems: order.OrderItem.Select(oi=>new OrderItemDto(
                    oi.OrderId.Value,
                    oi.ProductId.Value,
                    oi.Quantity,
                    oi.Price)).ToList()
            );
            orderDtos.Add(orderDto);
        }
        return orderDtos;
    }
}

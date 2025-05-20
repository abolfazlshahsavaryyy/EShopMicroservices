namespace Ordering.Application.Orders.Commands.CreateOrder;

class CreateOrderHandler
    (IApplicationDbContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //create order entity from the given command that has order dto
        //save to database
        //return the result

        var order = CreateNewOrder(request.order);


        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(order.Id.Value);
    }

    private Order CreateNewOrder(OrderDto orderDto)
    {
        var ShippingAddress = Address.Of(orderDto.ShippingAddress.FirstName,
            orderDto.ShippingAddress.LastName,
            orderDto.ShippingAddress.EmailAddress,
            orderDto.ShippingAddress.AddressLine,
            orderDto.ShippingAddress.Country,
            orderDto.ShippingAddress.State,
            orderDto.ShippingAddress.ZipCode);

        var BillingAddress= Address.Of(orderDto.BillingAddress.FirstName,
            orderDto.BillingAddress.LastName,
            orderDto.BillingAddress.EmailAddress,
            orderDto.BillingAddress.AddressLine,
            orderDto.BillingAddress.Country,
            orderDto.BillingAddress.State,
            orderDto.BillingAddress.ZipCode
            );

        var payment =Payment.Of
            (
            orderDto.Payment.CartName,
            orderDto.Payment.CartNumber,
            orderDto.Payment.Expiration,
            orderDto.Payment.Cvv,
            orderDto.Payment.PaymentMethod
            );

        var newOrder = Order.Create
            (
            orderId: OrderId.Of(Guid.NewGuid()),
            customerId: CustomerId.Of(orderDto.CustomerId),
            orderName: OrderName.Of(orderDto.OrderName),
            shippingAddress: ShippingAddress,
            billingAddress: BillingAddress,
            payment: payment


        

            );
        foreach(var orderitem in orderDto.OrderItems)
        {
            newOrder.Add(ProductId.Of(orderitem.ProductId), orderitem.Quantity, orderitem.Price);
        }
        return newOrder;

    }
}

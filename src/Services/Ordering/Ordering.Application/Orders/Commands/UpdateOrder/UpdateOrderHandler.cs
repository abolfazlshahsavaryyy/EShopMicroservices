

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderHandler
    (IApplicationDbContext dbContext)
    : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        //create Order object
        //save changes
        //return the result

        var orderId = OrderId.Of(command.OrderDto.Id);
        var order = await dbContext.Orders.
            FindAsync([orderId], cancellationToken: cancellationToken);

        if(order is null)
        {
            throw new OrderNotFoundException(command.OrderDto.Id);

        }

        UpdateOrderWithNewValue(order,command.OrderDto);

        dbContext.Orders.Update(order);
        var result=await dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            return new UpdateOrderResult(true);
        }
        else
        {
            return new UpdateOrderResult(false);
        }


    }

    private void UpdateOrderWithNewValue(Order existingOrder, OrderDto newOrder)
    {
        var updateBillingAddress = Address.Of(
            newOrder.BillingAddress.FirstName,
            newOrder.BillingAddress.LastName,
            newOrder.BillingAddress.EmailAddress,
            newOrder.BillingAddress.AddressLine,
            newOrder.BillingAddress.Country,
            newOrder.BillingAddress.State,
            newOrder.BillingAddress.ZipCode
            );

        var updpateShippingAddress = Address.Of
            (
            newOrder.ShippingAddress.FirstName,
            newOrder.ShippingAddress.LastName,
            newOrder.ShippingAddress.EmailAddress,
            newOrder.ShippingAddress.AddressLine,
            newOrder.ShippingAddress.Country,
            newOrder.ShippingAddress.State,
            newOrder.ShippingAddress.ZipCode
            );

        var updatePayment = Payment.Of
            (
            newOrder.Payment.CartName,
            newOrder.Payment.CartNumber,
            newOrder.Payment.Expiration,
            newOrder.Payment.Cvv,
            newOrder.Payment.PaymentMethod
            );

        existingOrder.Update
            (
            OrderName.Of(newOrder.OrderName),
            updpateShippingAddress,
            updateBillingAddress,
            updatePayment,
            status: newOrder.Status

            );
        
    }
}

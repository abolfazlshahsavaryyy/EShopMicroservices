
namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler
    (IApplicationDbContext dbContext)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext.Orders
            .FindAsync([orderId],cancellationToken);
        if(order is null)
        {
            throw new OrderNotFoundException(command.OrderId);
        }
        dbContext.Orders.Remove(order);
        var result=await dbContext.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            return new DeleteOrderResult(true);
        }
        else
        {
            return new DeleteOrderResult(false);
        }
    }
}

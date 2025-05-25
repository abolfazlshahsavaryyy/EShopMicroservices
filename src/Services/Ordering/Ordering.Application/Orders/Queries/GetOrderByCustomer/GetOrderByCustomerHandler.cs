namespace Ordering.Application.Orders.Queries.GetOrderByCustomer;
public class GetOrderByCustomerHandler
    (IApplicationDbContext dbContext) 
    :IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
{
    public async Task<GetOrderByCustomerResult> Handle(GetOrderByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders =await dbContext.Orders
            //.Include(o => o.OrderItem)
            .AsNoTracking()
            .Where(o => o.CustomerId ==CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync()
            .ConfigureAwait(false);

        var orderIds = orders
            .Select(o => o.Id.Value);
        var orderitems = await dbContext.OrderItems
            .Where(oi=>orderIds.Contains(oi.OrderId.Value))
            .ToListAsync();
        foreach (var order in orders)
        {
            foreach (var oi in orderitems)
            {
                if (oi.OrderId.Value == order.Id.Value)
                {
                    order.Add(oi.ProductId, oi.Quantity, oi.Price);
                    
                }
            }
        }

        return new GetOrderByCustomerResult(orders.ProjectToOrderDto());
    }
}

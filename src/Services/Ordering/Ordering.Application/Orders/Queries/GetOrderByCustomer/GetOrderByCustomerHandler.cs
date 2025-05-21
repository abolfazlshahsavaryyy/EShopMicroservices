namespace Ordering.Application.Orders.Queries.GetOrderByCustomer;
public class GetOrderByCustomerHandler
    (IApplicationDbContext dbContext) 
    :IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
{
    public async Task<GetOrderByCustomerResult> Handle(GetOrderByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders =await dbContext.Orders
            .Include(o => o.OrderItem)
            .AsNoTracking()
            .Where(o => o.CustomerId.Value == query.CustomerId)
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync();

        return new GetOrderByCustomerResult(orders.ProjectToOrderDto());
    }
}

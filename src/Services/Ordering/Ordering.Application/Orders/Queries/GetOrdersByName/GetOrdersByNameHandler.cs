using Ordering.Application.Extensions;

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

        //form 1
        var dtoOrders = orders.ProjectToOrderDto();
        return new GetOrderByNameResult(dtoOrders);

        //form 2
        return new GetOrderByNameResult(orders.ProjectToOrderDto());
    }

    
}

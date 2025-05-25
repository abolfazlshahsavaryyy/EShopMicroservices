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
            //.Include(o => o.OrderItem)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.Contains(query.name))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);

        var orderitems = await dbContext.OrderItems.ToListAsync();
        foreach(var order in orders)
        {
            foreach(var oi in orderitems)
            {
                if (oi.OrderId.Value == order.Id.Value)
                {
                    order.Add(oi.ProductId, oi.Quantity, oi.Price);
                }
            }
        }

        //form 1
        var dtoOrders = orders.ProjectToOrderDto();
        return new GetOrderByNameResult(dtoOrders);

        //form 2
        return new GetOrderByNameResult(orders.ProjectToOrderDto());
    }

    
}


namespace Ordering.Application.Orders.Queries.GetOrders;
public class GetOrderHandler(IApplicationDbContext dbContext)
: IQueryHandler<GetOrderQuery, GetOrderResult>
{
    public async Task<GetOrderResult> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var pageIndex = request.paginationRequest.PageIndex;
        var pageSize = request.paginationRequest.PageSize;
        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);
        var orders = await dbContext.Orders
            //.Include(o => o.OrderItem)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var orderIds = orders.Select(o => o.Id.Value); // Ensure this is materialized

        var orderitems = await dbContext.OrderItems
            .Where(oi => orderIds.Contains(oi.OrderId.Value)) // This now works
            .ToListAsync();
        foreach (var order in orders)
        {
            var itsOrderItems = orderitems.Where(oi => oi.OrderId.Value == order.Id.Value);
            foreach(var oi in itsOrderItems)
            {
                order.Add(oi.ProductId, oi.Quantity, oi.Price);
            }
        }
        var result = new GetOrderResult(new PaginatedResult<OrderDto>(pageIndex,
            pageSize,
            totalCount,
            orders.ProjectToOrderDto())
        );
        return result;
    }
}


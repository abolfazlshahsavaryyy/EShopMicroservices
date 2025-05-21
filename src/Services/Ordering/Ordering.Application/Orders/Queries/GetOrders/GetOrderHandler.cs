
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
            .Include(o => o.OrderItem)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var result = new GetOrderResult(new PaginatedResult<OrderDto>(pageIndex,
            pageSize,
            totalCount,
            orders.ProjectToOrderDto())
        );
        return result;
    }
}


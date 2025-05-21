
namespace Ordering.Application.Orders.Queries.GetOrders;
public record GetOrderResult(PaginatedResult<OrderDto> Orders);
public record GetOrderQuery(PaginationRequest paginationRequest)
    :IQuery<GetOrderResult>;


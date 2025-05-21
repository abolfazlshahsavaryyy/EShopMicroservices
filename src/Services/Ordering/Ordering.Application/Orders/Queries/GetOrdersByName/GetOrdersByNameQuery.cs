namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public record GetOrderByNameResult(IEnumerable<OrderDto> orders);
public record GetOrdersByNameQuery(string name)
    :IQuery<GetOrderByNameResult>;


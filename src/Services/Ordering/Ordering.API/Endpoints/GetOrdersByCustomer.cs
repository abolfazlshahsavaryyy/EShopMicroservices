using Ordering.Application.Orders.Queries.GetOrderByCustomer;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.API.Endpoints;

public record GetOrderByCustomerReponse(IEnumerable<OrderDto> orders);
public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrderByCustomerQuery(customerId));
            var response = new GetOrderByCustomerReponse(result.orders);
            return Results.Ok(response);
        }).WithName("Get Order By Customer")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Order By Customer endpint")
        .WithDescription("this ennpoint enable to get orders with its customer Id");
    }
}

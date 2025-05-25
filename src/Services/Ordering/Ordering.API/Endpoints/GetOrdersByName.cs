using Ordering.Application.Orders.Queries.GetOrdersByName;
using Ordering.Domain.Models;

namespace Ordering.API.Endpoints;

public record GetOrderByNameReponse(IEnumerable<Order> orders);
public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("orders/{name}", async (string name,ISender sender) =>
        {
            var query = new GetOrdersByNameQuery(name);
            var result = await sender.Send(query);
            var response = new GetOrderByNameResult(result.orders);
            return Results.Ok(response);

        })
            .WithName("Get Order By Name")
            .Produces<GetOrderByNameReponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Name endpint")
            .WithDescription("this ennpoint enable to get orders with its name"); ;
    }
}

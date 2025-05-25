using BuildingBlocks.Paggination;
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints;

public record GetOrderResponse(PaginatedResult<OrderDto> Orders);
public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters]PaginationRequest request,ISender sender) =>
        {
            var result = await sender.Send(new GetOrderQuery(request));
            var response = request.Adapt<GetOrderResponse>();
            return Results.Ok(response);
        }).WithName("Get Order")
        .Produces<GetOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders endpint")
        .WithDescription("this enpoint enable to get orders");
    }
}

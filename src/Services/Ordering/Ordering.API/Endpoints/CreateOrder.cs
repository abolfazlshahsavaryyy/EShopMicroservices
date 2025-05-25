namespace Ordering.API.Endpoints;

public record CreateOrderRequest(OrderDto order);
public record CreateOrderResponse(Guid Id);
public class CreateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("orders/", async (CreateOrderRequest request,ISender sender) =>
        {
            var command = new CreateOrderCommand(request.order);

            var result = await sender.Send(command);

            var respones = result.Adapt<CreateOrderResponse>();
            return Results.Created($"orders/{respones.Id}",respones);
        })
            .WithName("Create Order")
            .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Order endpint")
            .WithDescription("this ennpoint enable to create new order");
    }
}

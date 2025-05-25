
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.Endpoints
{
    public record UpdateOrderRequest(OrderDto OrderDto);
    public record UpdareOrderReponse(bool IsSeccuss);
    public class UpdateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("orders", async (UpdateOrderRequest request,ISender sender) =>
            {
                var command = request.Adapt<UpdateOrderCommand>();
                var result = await sender.Send(command);
                var respones = result.Adapt<UpdareOrderReponse>();
                return Results.Ok(respones);
            })
             .WithName("UpdateOrder")
            .Produces<CreateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Order endpint")
            .WithDescription("this enpoint enable to update existing order"); ;
        }
    }
}

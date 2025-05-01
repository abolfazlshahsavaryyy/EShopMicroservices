
using Microsoft.AspNetCore.Http.HttpResults;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{username}",
                async (string username, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(username));
                var response = result.Adapt<DeleteBasketResponse>();
                if (response.IsSuccess == true)
                {
                    return Results.Ok(response);
                }
                else
                {
                    return Results.NotFound(response);
                }
            }).WithName("Delete Cart")
            .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Cart by givin username");
        }
    }
}

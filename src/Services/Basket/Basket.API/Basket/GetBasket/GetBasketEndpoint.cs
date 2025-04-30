using Basket.API.Models;
using Mapster;
using MediatR;

namespace Basket.API.Basket.GetBasket
{
    //public record GetBasketequest(string username);
    public record GetBasketResponse(ShopingCart Cart);
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(username));
                var response = result.Adapt<GetBasketResponse>();
                return Results.Ok(response);
            }).WithName("GetAllBasket")
            .Produces<GetBasketQuery>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Get all baskets");
        }
    }
}

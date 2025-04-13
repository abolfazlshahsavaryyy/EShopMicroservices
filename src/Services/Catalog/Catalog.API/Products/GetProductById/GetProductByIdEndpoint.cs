
namespace Catalog.API.Products.GetProductById
{
    //public record GetProductByIdRequest();
    public record GetProductByIdResponse( Product product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.Map("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = new GetProductByIdResponse(result.product);
                return Results.Ok(response);
            })
             .WithName("GetProductById")
             .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Get product by Id")
             .WithDescription("Get Product by Id witch Id is Guid");
        }
    }
}

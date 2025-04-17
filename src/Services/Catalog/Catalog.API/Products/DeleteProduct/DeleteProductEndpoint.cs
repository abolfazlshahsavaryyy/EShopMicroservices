
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                var response = new DeleteProductResponse(result.IsSuccess);
                if (response.IsSuccess)
                {
                    return Results.Ok(response);
                }
                else
                {
                    return Results.NotFound(response);
                }
            }).WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .Produces<DeleteProductResponse>(StatusCodes.Status404NotFound)
            ;
        }
    }
}

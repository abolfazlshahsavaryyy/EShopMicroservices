﻿
using Remotion.Linq.Clauses.ResultOperators;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/category/{category}",
                async (string category, ISender sender) =>
            {
                var result =await sender.Send(new GetProductByCategoryQuery(category));
                var response = new GetProductByCategoryResponse(result.products);
                return Results.Ok(response);
            })
                .WithName("GetProductByCategory")
                .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product using category")
                .WithDescription("Get Product using category");
        }
    }
}

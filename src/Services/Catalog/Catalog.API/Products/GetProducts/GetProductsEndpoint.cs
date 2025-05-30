﻿namespace Catalog.API.Products.GetProducts;
public record GetProductsRequest(int? pageSize=10,int? pageNumber=1);
public record GetProductsResponse(IEnumerable<Product> Products);
public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters]GetProductsRequest request  ,ISender sender) =>
        {

            var query = new GetProductQuery(request.pageSize, request.pageNumber);
            var result =await sender.Send(query);
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);

        }).WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get products")
        .WithDescription("Get all Products");
    }
}


namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdResult(Product product);
    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;
    internal class GetProductByIdHandler
        (IDocumentSession session,ILogger<GetProductByIdHandler> logger)  
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id,cancellationToken);
            if (product is null)
            {
                string content = $"product not found with Id :{query.Id}";
                logger.LogWarning(content);
                throw new NotFoundProductException(query.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}

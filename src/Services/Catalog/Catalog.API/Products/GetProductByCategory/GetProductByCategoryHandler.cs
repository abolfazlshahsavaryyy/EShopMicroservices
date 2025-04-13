
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryResult(IEnumerable<Product> products);
    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
    internal class GetProductByCategoryHandler
        (IDocumentSession session,ILogger<GetProductByCategoryHandler> logger) :
        IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"getProductByCategory has been called with Category{query.Category}");

            var products = await session.Query<Product>()
                .Where(p=>p.Category.Contains(query.Category)).ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }
}

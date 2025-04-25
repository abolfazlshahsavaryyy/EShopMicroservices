namespace Catalog.API.Products.GetProducts
{
    public record GetProductResult(IEnumerable<Product> Products);
    public record GetProductQuery() : IQuery<GetProductResult>;
    internal class GetProductsHandler(IDocumentSession session)
        : IQueryHandler<GetProductQuery, GetProductResult> 
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products =await session.Query<Product>().ToListAsync(cancellationToken);
            var result = new GetProductResult(products);
            return result;
            ;
        }
    }
}

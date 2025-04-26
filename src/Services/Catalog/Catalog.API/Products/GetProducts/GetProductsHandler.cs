using Marten.Pagination;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductResult(IEnumerable<Product> Products);
    public record GetProductQuery(int? pageSize = 10, int? pageNumber = 1) : IQuery<GetProductResult>;
    internal class GetProductsHandler(IDocumentSession session)
        : IQueryHandler<GetProductQuery, GetProductResult> 
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session
                .Query<Product>()
                .ToPagedListAsync(query.pageNumber ?? 1, query.pageSize ?? 10, cancellationToken);
                
            var result = new GetProductResult(products);
            return result;
            ;
        }
    }
}


using Marten.Linq.SoftDeletes;

namespace Catalog.API.Products.UpdateProduc
{
    public record UpdateProductCommad(Guid Id, string Name, List<string> Category, 
        string Description, string ImageFile, decimal Price):
        ICommand<UpdateProductResult>
        ;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductHandler
        (IDocumentSession session,ILogger<UpdateProductHandler> logger) 
        : ICommandHandler<UpdateProductCommad, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommad command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"update endpoint has been called for Id: {command.Id}");
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if(product is null)
            {
                throw new NotFoundProductException(command.Id);

            }
            product.Name = command.Name;
            product.Category = command.Category;
            product.Decription = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
            
        }
    }
}

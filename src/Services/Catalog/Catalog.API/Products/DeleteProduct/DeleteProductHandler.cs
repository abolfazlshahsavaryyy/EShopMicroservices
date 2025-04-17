
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
    internal class DeleteProductHandler
        (IDocumentSession session,ILogger<DeleteProductHandler> logger)
        :ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Command with Id of {command.Id} want be deleted");
            try
            {
                session.Delete<Product>(command.Id);
                await session.SaveChangesAsync(cancellationToken);
                logger.LogInformation($"Product with Id of {command.Id} has been deleted");
                return new DeleteProductResult( true);
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return new DeleteProductResult(false);
            }
        }
    }
}

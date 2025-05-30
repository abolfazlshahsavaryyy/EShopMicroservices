﻿
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductValidation : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidation()
        {
            RuleFor(d => d.Id).NotNull().WithMessage("Id is requi red");
        }
    }
    internal class DeleteProductHandler
        (IDocumentSession session,ILogger<DeleteProductHandler> logger)
        :ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
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

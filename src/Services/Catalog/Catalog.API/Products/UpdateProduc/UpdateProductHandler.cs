
using Marten.Linq.SoftDeletes;

namespace Catalog.API.Products.UpdateProduc
{
    public record UpdateProductCommad(Guid Id, string Name, List<string> Category, 
        string Description, string ImageFile, decimal Price):
        ICommand<UpdateProductResult>
        ;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductValidator : AbstractValidator<UpdateProductCommad>
    {
        public UpdateProductValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Product Id requered");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is requerd")
                .Length(2, 150).WithMessage("name must be between 2 to 150");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
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
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
            
        }
    }
}

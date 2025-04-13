namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //business logic to add product
            //step1:Create Product entity using command
            var product = new Product
            {
                Name = command.Name,
                Category=command.Category,
                Decription=command.Description,
                ImageFile=command.ImageFile,
                Price=command.Price
            };

            //TODO
            //step2:save in database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //skip ...
            //TODO

            //step3:return the CreateProductResult object
            var result =new CreateProductResult(product.Id);
            return result;
            
        }
    }
}

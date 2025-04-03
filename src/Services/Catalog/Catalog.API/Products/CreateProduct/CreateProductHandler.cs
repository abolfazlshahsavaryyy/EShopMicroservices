using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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
            //skip ...
            //TODO

            //step3:return the CreateProductResult object
            var result =new CreateProductResult(Guid.NewGuid());
            return result;
            
        }
    }
}

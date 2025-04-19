﻿using FluentValidation;

namespace Catalog.API.Products.CreateProduct
{
    //Create Product Command and Result type
    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    //validation for command type

    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is requierd");
            RuleFor(p => p.Category).NotEmpty().WithMessage("Category can't be empty");
            RuleFor(p => p.ImageFile).NotEmpty().WithMessage("ImageFile is requierd");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price can't be negetive");
        }
    }
    internal class CreateProductCommandHandler
        (IDocumentSession session,ILogger<CreateProductCommandHandler> logger)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Create product has been call for new product with name {command.Name}");
            
            //business logic to add product
            //step1:Create Product entity using command
            var product = new Product
            {
                Name = command.Name,
                Category=command.Category,
                Description=command.Description,
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

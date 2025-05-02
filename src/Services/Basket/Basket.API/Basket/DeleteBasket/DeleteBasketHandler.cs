using Basket.API.Data;
using BuildingBlocks.CQRS;
using FluentValidation;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Windows.Input;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string Username):ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(c => c.Username).NotNull().NotEmpty().WithMessage("Username is Required");
        }
    }
    public class DeleteBasketHandler
        (IBasketRepository repo)
        : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await repo.DeleteBasket(request.Username, cancellationToken);
            return new DeleteBasketResult(result);
        }
    }

}

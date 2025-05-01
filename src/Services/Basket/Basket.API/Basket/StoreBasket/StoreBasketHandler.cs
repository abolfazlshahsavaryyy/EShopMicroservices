using BuildingBlocks.CQRS;
using FluentValidation;
using System.Windows.Input;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShopingCart Cart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string Usename);
    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can't be null");
            RuleFor(x => x.Cart.Username).NotEmpty().WithMessage("Username is Required");
        }
    }
    public class StoreBasketHandler :
        ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            ShopingCart shoppingCart = request.Cart;
            //TODO Store the new Shopping Cart to Db or Update it 
            //TODO Update Cash
            return new StoreBasketResult("swn");

        }
    }
}

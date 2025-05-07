using Basket.API.Data;
using BuildingBlocks.CQRS;
using Discount.Grpc;
using FluentValidation;
using System.Diagnostics;
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
    public class StoreBasketHandler
        (IBasketRepository repo,DiscountProtoService.DiscountProtoServiceClient discountService) 
        :ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {

            ShopingCart cart = request.Cart;
            DeductDiscount(cart, cancellationToken);
            var res = await repo.StoreBasket(cart, cancellationToken);
            return new StoreBasketResult(res.Username ?? "");

        }
        private async Task DeductDiscount(ShopingCart cart,CancellationToken token)
        {
            foreach(var item in cart.Items)
            {
                var coupon = await discountService.GetDiscountAsync(new GetDiscountRequest
                {
                    ProductName = item.ProductName
                }, cancellationToken: token);
                item.Price -= coupon.Amount;
            }
        }
    }
}

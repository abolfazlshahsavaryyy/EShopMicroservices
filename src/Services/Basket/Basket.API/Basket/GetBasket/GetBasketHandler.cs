using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string Username) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShopingCart Cart);
    public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async  Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            //TODO get the basket from the database 
            //var basket =await _repository.GetBasket(request.Username);
            var res = new GetBasketResult(new ShopingCart
            {
                Username="swn",
                Items= new List<ShopingCartItem>
                {
                       
                    new ShopingCartItem
                    {
                        ProductName="laptop",
                        Price=1200,
                        Quantity=2,
                        Color="black",
                    }
                }
            });
            return res;
        }
    }
}

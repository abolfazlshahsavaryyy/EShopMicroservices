using Basket.API.Data;
using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string Username) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShopingCart Cart);
    public class GetBasketHandler 
        (IBasketRepository repo)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async  Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            //TODO get the basket from the database 
            //var basket =await _repository.GetBasket(request.Username);
            var basket = await repo.GetBasket(request.Username);
            return new GetBasketResult(basket);
        }
    }
}

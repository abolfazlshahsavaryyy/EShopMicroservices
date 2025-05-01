namespace Basket.API.Data
{
    public class BasketRepository
        (IDocumentSession session)
        : IBasketRepository
    {
        public async Task<ShopingCart> GetBasket(string username, CancellationToken token = default)
        {
            var basket = await session.LoadAsync<ShopingCart>(username, token);
            return basket is null? throw new BasketNotFoundException(username):basket;
        }
        public async Task<ShopingCart> StoreBasket(ShopingCart cart, CancellationToken token = default)
        {
            session.Store(cart);
            await session.SaveChangesAsync(token);
            return cart;

        }
        public async Task<bool> DeleteBasket(string username, CancellationToken token = default)
        {
            session.Delete<ShopingCart>(username);
            await session.SaveChangesAsync(token);
            return true;


        }

        

        
    }
}

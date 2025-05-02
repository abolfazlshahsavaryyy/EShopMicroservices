
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachBasketRepository 
        (IBasketRepository repo,IDistributedCache cache)
        : IBasketRepository
    {
        public async Task<ShopingCart> GetBasket(string username, CancellationToken token = default)
        {
            var cashedBasket = await cache.GetStringAsync(username, token);
            if (!String.IsNullOrEmpty(cashedBasket))
            {
                return JsonSerializer.Deserialize<ShopingCart>(cashedBasket);
            }
            else
            {
                var basket=await repo.GetBasket(username, token);
                await cache.SetStringAsync(username, JsonSerializer.Serialize(basket),token);
                return basket;
            }
        }
        public async Task<bool> DeleteBasket(string username, CancellationToken token = default)
        {

            var result= await repo.DeleteBasket(username, token);
            await cache.RemoveAsync(username, token);
            return result;
        }

        

        public async Task<ShopingCart> StoreBasket(ShopingCart cart, CancellationToken token = default)
        {
            var basket=await repo.StoreBasket(cart, token);
            await cache.SetStringAsync(cart.Username, JsonSerializer.Serialize(cart),token);
            return basket;
        }
    }
}

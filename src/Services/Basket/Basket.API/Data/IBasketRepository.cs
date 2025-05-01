namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<ShopingCart> GetBasket(string username, CancellationToken token=default);
        Task<ShopingCart> StoreBasket(ShopingCart cart, CancellationToken token = default);
        Task<bool> DeleteBasket(string username, CancellationToken token = default);
    }
}

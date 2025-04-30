namespace Basket.API.Models
{
    public class ShopingCart
    {
        public string Username { get; set; } = default;
        public List<ShopingCartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
        public ShopingCart(string Username)
        {
            this.Username = Username;
        }
        //required for create non username shoping cart
        public ShopingCart()
        {
            
        }
    }
}


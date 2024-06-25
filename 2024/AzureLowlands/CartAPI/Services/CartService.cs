using CartAPI.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CartAPI.Services{
    public class CartService:ICartService{
        private readonly IDatabase _redisDatabase;

        public CartService(RedisConnection redisConnection){
            _redisDatabase = redisConnection.Connection.GetDatabase();
        }

        public async Task AddToCart(Product product){
            var cartValue = await _redisDatabase.StringGetAsync("cart");
            var cartJson = cartValue.ToString();
            var cart = JsonConvert.DeserializeObject<Cart>(cartJson) ?? new Cart();

            cart.LineItems ??= new List<LineItem>();

            var existingItem = cart.LineItems.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem == null){
                cart.LineItems.Add(new LineItem(){
                    Product = product,
                    Quantity = 1
                });
            }
            else{
                existingItem.Quantity += 1;
            }

            var serializedCart = JsonConvert.SerializeObject(cart);
            await _redisDatabase.StringSetAsync("cart", serializedCart);
        }

        public async Task<Cart> GetCart(){
            var cartValue = await _redisDatabase.StringGetAsync("cart");
            var cartJson = cartValue.ToString();
            var cart = JsonConvert.DeserializeObject<Cart>(cartJson) ?? new Cart();

            return cart;
        }

        public async Task ClearCart(){
            await _redisDatabase.KeyDeleteAsync("cart");
        }

        // create a method to remove a lineitem from the cart
        // decrease quantity if item already exists
        // remove lineitem if quantity is 0
        public async Task RemoveFromCart(LineItem lineItem){
            var cartValue = await _redisDatabase.StringGetAsync("cart");
            var cartJson = cartValue.ToString();
            var cart = JsonConvert.DeserializeObject<Cart>(cartJson) ?? new Cart();

            cart.LineItems ??= new List<LineItem>();

            var existingItem = cart.LineItems.FirstOrDefault(i => i.Product.Id == lineItem.Product.Id);

            if (existingItem == null){
                return;
            }
            else{
                existingItem.Quantity -= 1;
                if (existingItem.Quantity == 0){
                    cart.LineItems.Remove(existingItem);
                }
            }

            var serializedCart = JsonConvert.SerializeObject(cart);
            await _redisDatabase.StringSetAsync("cart", serializedCart);
        }
    }
}
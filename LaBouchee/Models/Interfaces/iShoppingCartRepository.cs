namespace LaBouchee.Models.Interfaces
{
    public interface iShoppingCartRepository
    {
        void AddToCart(Product product);
        int RemoveFromCart(Product product);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();

        decimal GetShoppingCartTotal();

        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }

    }
}

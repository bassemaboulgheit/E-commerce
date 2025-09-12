using E_commerce.Models;

namespace E_commerce.Application.Services
{
    public interface ICartItemService
    {
        public List<CartItem> GetAllCartItems();
        public void CreateCartItem(CartItem cartItem);
        public void DeleteCartItem(CartItem cartItem);
        public void UpdateCartItem(CartItem cartItem);
        public int SaveCartItem();
    }

}

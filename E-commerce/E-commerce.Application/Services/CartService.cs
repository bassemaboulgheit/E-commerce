using E_commerce.Application.Contracts;
using E_commerce.Models;

namespace E_commerce.Application.Services
{
    public class CartService : ICartService
    {
        //ICategoryRepository _CategoryRepo;
        IGenericRepository<Cart, int> _cartRepo;

        public CartService(IGenericRepository<Cart, int> cart)
        {
            _cartRepo = cart;
        }

        public void CreateCart(Cart category)
        {
            Cart newcart = new Cart()
            {
                CreatedAt = DateTime.Now,
            };
            //Category newcart = category.Adapt<Category>();
            _cartRepo.create(newcart);
        }


    }
}

using E_commerce.Application.Contracts;
using E_commerce.Models;

namespace E_commerce.Application.Services
{
    public class CartItemService : ICartItemService
    {
        //ICategoryRepository _CategoryRepo;
        IGenericRepository<CartItem, int> _cartitemRepo;

        public CartItemService(IGenericRepository<CartItem, int> itemrepo)
        {
            _cartitemRepo = itemrepo;
        }
        public List<CartItem> GetAllCartItems()
        {
            //IQueryable<Category> allcategoriesquery = _CategoryRepo.GetAll();
            //var allcats = allcategoriesquery.Where(c => c.Products.Count > 0)
            //    .Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
            //.Adapt<List<Category>>();
            //return allcats;
            return _cartitemRepo.GetAll().ToList();
        }

        public void CreateCartItem(CartItem cartItem)
        {
            CartItem cartIte = new CartItem()
            {
                Quantity = cartItem.Quantity,
            };
            //Category newcat = category.Adapt<Category>();
            _cartitemRepo.create(cartIte);
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            if (cartItem != null)
            {
                cartItem.IsDeleted = true;
            }
            else
            {
                throw new Exception("cartItem not found");
            }
            _cartitemRepo.delete(cartItem);
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _cartitemRepo.Update(cartItem);
        }

        public int SaveCartItem()
        {
            return _cartitemRepo.Save();
        }
    }
}

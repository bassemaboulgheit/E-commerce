using E_commerce.Application.Contracts;
using E_commerce.Models;

namespace E_commerce.Application.Services
{
    public class OrderService : IOrderService
    {
        //ICategoryRepository _CategoryRepo;
        IGenericRepository<Order, int> _orderRepo;

        public OrderService(IGenericRepository<Order, int> orderrepo)
        {
            _orderRepo = orderrepo;
        }
        public List<Order> GetAllOrder()
        {
            //IQueryable<Category> allcategoriesquery = _CategoryRepo.GetAll();
            //var allcats = allcategoriesquery.Where(c => c.Products.Count > 0)
            //    .Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
            //.Adapt<List<Category>>();
            //return allcats;
            return _orderRepo.GetAll().ToList();
        }

        public void CreateOrder(Order Order)
        {
            Order Order1 = new Order()
            {
                OrderDate = Order.OrderDate,
                orderStatus = OrderStatus.Pending,
            };
            //Category newcat = category.Adapt<Category>();
            _orderRepo.create(Order1);
        }

        public void DeleteOrder(Order order)
        {
            if (order != null)
            {
                order.IsDeleted = true;
            }
            else
            {
                throw new Exception("Order not found");
            }
            _orderRepo.delete(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepo.Update(order);
        }

        public int SaveOrder()
        {
            return _orderRepo.Save();
        }
    }
}
